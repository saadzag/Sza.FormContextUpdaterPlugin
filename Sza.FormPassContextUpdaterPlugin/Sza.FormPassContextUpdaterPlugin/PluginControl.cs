using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk.Metadata;

namespace Sza.FormPassContextUpdaterPlugin
{
    public partial class PluginControl : PluginControlBase
    {
        private Settings mySettings;

        public PluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }
        private void UpdateForm_Click(object sender, EventArgs e)
        {
            EntityCollection entityCollection = new EntityCollection();
            if (formlistView.SelectedItems.Count > 0)
            {
                for (var i =0; i<formlistView.SelectedItems.Count; i++)
                {
                    entityCollection.Entities.Add((Entity)formlistView.SelectedItems[i].Tag);
                }


                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Updating and publishing selected forms",
                    Work = (worker, args) =>
                    {

                        args.Result = PluginService.UpdateForms(Service, entityCollection);
                    },
                    PostWorkCallBack = (args) =>
                    {
                     
                            MessageBox.Show("Saved and Published");

                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                });
            }
            
        }
        private void loadEntites_Click(object sender, EventArgs e)
        {
            entitieslistView.Items.Clear();
            formlistView.Items.Clear();
            ExecuteMethod(LoadEntites);
        }
        private void EntitySelect_Click(object sender, EventArgs e)
        {
            string asyncArgument = entitieslistView.SelectedItems[0].Tag.ToString();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading forms",
                Work = (worker, args) =>
                {
                    args.Result = PluginService.GetFormsByEntity(Service, asyncArgument);
                },
                PostWorkCallBack = (args) =>
                {
                    List<ListViewItem> list = new List<ListViewItem>();
                    EntityCollection result = (EntityCollection)args.Result;
                    if (result.Entities.Count > 0)
                    {
                        foreach (Entity item in result.Entities)
                        {
                            string desc = "";
                            if (item.Contains("description")) desc = item.Attributes["description"].ToString();
                                ListViewItem listViewItem = new ListViewItem
                            {
                                Tag = item,
                                SubItems =
                            {
                                        item.Attributes["objecttypecode"].ToString(),
                                    item.Attributes["name"].ToString(),
                                 desc
                            }
                            };
                            formlistView.Items.Add(listViewItem);
                            checkOptionButton.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No form found");
                    }

                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });
        }
        private void LoadEntites()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading entities",
                Work = (worker, args) =>
                {
                    args.Result = PluginService.GetEntities(Service);
                },
                PostWorkCallBack = (args) =>
                {
                    List<ListViewItem> list = new List<ListViewItem>();
                    List<EntityMetadata> result = (List<EntityMetadata>)args.Result;
                    if (result.Count >0)
                    {
                        foreach (EntityMetadata item in result)
                        {
                            ListViewItem listViewItem = new ListViewItem
                            {
                                Text = item.DisplayName.UserLocalizedLabel.Label,
                                Tag = item.LogicalName,
                                SubItems =
                                 {
                                    //item.DisplayName.UserLocalizedLabel.Label,
                                    item.LogicalName
                                }
                            };
                            //listViewItem.SubItems.Add(item.LogicalName);
                            list.Add(listViewItem);
                        }
                        entitieslistView.Items.AddRange(list.ToArray());

                    }
                    else
                    {
                        MessageBox.Show("No entity found");
                    }
                       
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });
        }
        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }
    }
}