using System;
using System.IO;
using System.Reflection;

namespace MattBerther.Web.UI.WebControls
{
	public class ScriptHandler
	{
        public static string GetScript(string scriptName)
        {
            Assembly asm = typeof(ScriptHandler).Assembly;
            string script = "";

            try
            {
                using (StreamReader rdr = new StreamReader(asm.GetManifestResourceStream(typeof(ScriptHandler), scriptName)))
                {
                    script = rdr.ReadToEnd();
                }
            }
            catch (ArgumentNullException) {}

            return String.Format("<script language='javascript' type='text/javascript'>\r\n<!--\r\n{0}\r\n// -->\r\n</script>",
                script);            
        }
	}
}
