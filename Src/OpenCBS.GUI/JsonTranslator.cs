// Copyright © 2013 Open Octopus Ltd.
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
// 
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using OpenCBS.Interface;

namespace OpenCBS.GUI
{
    public class JsonTranslator : ITranslator
    {
        private Dictionary<string, string> _strings;

        public string Translate(string key)
        {
            if (_strings == null) return key;
            return !_strings.ContainsKey(key) ? key : _strings[key];
        }

        public void Reload()
        {
            _strings = null;
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(path)) return;
            
            var fileName = string.Format("{0}.json", CultureInfo.CurrentUICulture.Name);
            path = Path.Combine(path, "Languages");
            path = Path.Combine(path, fileName);
            if (!File.Exists(path)) return;

            _strings = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
        }
    }
}
