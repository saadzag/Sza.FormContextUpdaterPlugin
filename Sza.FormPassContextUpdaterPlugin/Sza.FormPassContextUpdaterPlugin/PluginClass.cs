﻿using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Sza.FormPassContextUpdaterPlugin
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Form Context Updater"),
        ExportMetadata("Description", "This is a description for my first plugin"),
       ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAIAAAD8GO2jAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMjHxIGmVAAADyklEQVRIS92WSSitYRzGP2MyjxtcMmQIC5EpUizcZFpZSBZO3UQZF0LmsFI3unRZ2AkbSrFhgyLdkCGUSMpMIkOme5++5z1fX5fvO5uzufe3OJ33 + f / f93nPO / zfI / 0vuLu79 / b2 / jQfLi4uYmji7 + 9 / f3//23x4e3uLoYna4OjoqK6uLj4+/otMQkJCS0vL+fk5owojIyNfjQwNDQnViKbB1dWVn5+fUFWEhYWpf+LLy0t4eLiISVJwcPD7+7uIyWgaNDc3U0lNTV1fX8c0HRwcqAwODrIzWFlZsbGxoU7m5uZETEbToLCwkEpMTMzS0tLz8zN2rLOzE58YlJ1BbW0t0zIyMviluLhYxGQ0DTBlCwsLoUoSpo8lxtyvr6/ZE2B9fH19EcVR2dzctLKywncfH5+7uzuRoWPw9vZWX1/PPmqQsLe3x87T09MUk5OTkZ+YmMjmxMQEE4CmAdnd3cVmpKSkeHp6igxJys7Oxk4C/CYqDQ0NNzc3jY2NbKalpYn+WgYAB66rq6umpgYeGAuHKi8vjzmBgYGPj4+Hh4fKtjs6OuKG4pNNS0vLg4MDEwZKoLS0FGuNFWhqaqISHR0Npa+vj81PaW1t1TNAAAeGCqYTFBQUFRVlbW1NpaenBwlxcXFs5uTkfDeSnp5OMTIyEgdPz+D19dVgMNjb24uAjJubG3Yev2Zra4sKTsHa2hryyczMDHXMZnV1FYqmAcBAJycnk5OTP2SmpqYuLy8Zuri4+CWDUTAVigBLRx2cnZ1B0TMgCwsLA0aUrSOLi4u4dyI2MIBbMjo6iguhtjRtEBERIWKSVF5eLlSZ6upqEVCBypGVlXV7e8scEwbLy8siIBMQEPDw8CBiKgMcBCcnJ3VRys/Pxwojx4RBUVERdS8vL3yieMzOzoqYyiAkJAS7hQXEuFRsbW339/eRo2eA0u/q6goRZwlrzQQcSkaBYoCKzUOJKmRnZ0exv78fip4Bdowi1hSz45HF+Ts9PWXCRwOAB4NiRUUFmnoGmZmZFIeHh7GguMBsdnd3M+FTA+VQlJWVoalpcHx8zFKKdc/NzS0oKFCmFhsbi/OOnI8GqFooShQ7Ojr0DNrb24X0AWzgzs6O2iA0NBTVELcP1YIKJodbommAYqk8yChEKDtE+Q9SWVmpNsBwHh4eiCpvVFJSkl4tmp+fV56ajY0N5BHlgcTzgEkoBmpwJ7CGJsr1+Pj4N5mqqiosK1MBzKiD7e3tsbEx0ZApKSlpa2tDaXl6ehIddPbAXPxt4OzsjIKDh8xcKM/cv44k/QE24raL5wmBJQAAAABJRU5ErkJggg=="),
  ExportMetadata("BigImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAMAAAC5zwKfAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAMAUExURQAAAAEBAQICAgMDAwQEBAUFBQYGBgcHBwgICAkJCQoKCgsLCwwMDA4ODg8PDxAQEBERERISEhMTExQUFBUVFRYWFhcXFxgYGBkZGRoaGh0dHSEhISMjIyQkJCUlJSYmJicnJygoKCkpKSoqKisrKywsLC0tLS4uLjAwMDExMTIyMjQ0NDU1NTY2Njc3Nzg4ODk5OTo6Ojs7Ozw8PD09PT4 + Pj8 / P0BAQEFBQUJCQkNDQ0REREVFRUZGRkdHR0hISElJSUpKSkxMTE1NTU5OTlBQUFFRUVJSUlRUVFZWVldXV1hYWFlZWVpaWltbW1xcXF1dXV5eXmBgYGFhYWJiYmNjY2VlZWZmZmdnZ2hoaGlpaWpqamtra21tbW9vb3BwcHFxcXNzc3R0dHV1dXZ2dnd3d3h4eHp6enx8fH19fX9 / f4CAgIGBgYKCgoODg4SEhIaGhoeHh4iIiImJiYqKiouLi42NjY6OjpCQkJGRkZKSkpOTk5aWlpiYmJmZmZubm52dnZ6enqCgoKKioqOjo6SkpKWlpaampqenp6ioqKmpqaqqqqurq6ysrK2tra6urq + vr7CwsLGxsbKysrOzs7S0tLa2tre3t7i4uLm5ubq6ury8vL6 + vr +/ v8DAwMHBwcLCwsPDw8XFxcbGxsfHx8jIyMnJycrKysvLy8zMzM3Nzc7Ozs / Pz9DQ0NHR0dPT09TU1NXV1dbW1tfX19jY2NnZ2dzc3N3d3d7e3t / f3 + Dg4OHh4eLi4uPj4 + Tk5OXl5ebm5ufn5 + jo6Onp6erq6uvr6 + zs7O3t7e7u7u / v7 / Dw8PLy8vPz8 / T09PX19fb29vf39 / j4 + Pn5 + fr6 + vv7 +/ z8 / P39 / f7 +/ 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"),
        ExportMetadata("BackgroundColor", "Gray"),
        ExportMetadata("PrimaryFontColor", "#000000"),
        ExportMetadata("SecondaryFontColor", "DarkGray")]
    public class PluginClass : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new PluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public PluginClass()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}