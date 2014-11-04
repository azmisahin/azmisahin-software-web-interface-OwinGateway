using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace OwinGate
{
	public class Logger
	{
		private readonly Func<IDictionary<string, object>, Task> _next;

        /// <summary>
        /// Async Invoke Dictionary
        /// </summary>
        /// <param name="next"></param>
		public Logger(Func<IDictionary<string, object>, Task> next)
		{
			if (next == null)
			{
				throw new ArgumentNullException("next");
			}
			_next = next;
		}

        /// <summary>
        /// Async Loger Method
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
		public Task Invoke(IDictionary<string, object> environment)
		{
            string method = GetValueFromEnvironment(environment, OwinConstants.RequestMethod);
            string path = GetValueFromEnvironment(environment, OwinConstants.RequestPath);
            string RemoteIpAddress = GetValueFromEnvironment(environment, OwinConstants.RemoteIpAddress);
            int isStatics;
            string requestBody;
            Stream stream = (Stream)environment[OwinConstants.RequestBody];
            using (StreamReader sr = new StreamReader(stream))
			{
				requestBody = sr.ReadToEnd();
			}
            environment[OwinConstants.RequestBody] = new MemoryStream(Encoding.UTF8.GetBytes(requestBody));
            string StartFormat = "{0};{1};{2};" + Environment.NewLine;
            #region Filter and Write [ Start ]
            isStatics = path.IndexOf("Statics");
            if (isStatics==-1)
            {
                //Text File Insert
                WriteLog(string.Format(StartFormat, DateTime.Now.ToString(), RemoteIpAddress, path));
                //Database Insert
                WriteDatabase(string.Format(StartFormat, DateTime.Now.ToString(), RemoteIpAddress, path));
            }
            #endregion
            Stopwatch stopWatch = Stopwatch.StartNew();
            return _next(environment).ContinueWith(t =>{
                string StopFormat = "";
                #region Stop Watch Format 1
                //StopFormat = "Stop\t{0}\t{1}\t{2}\t{3}\t{4}" + Environment.NewLine;
                //WriteLog(string.Format(StopFormat, method, path, stopWatch.ElapsedMilliseconds,
                //    GetValueFromEnvironment(environment, OwinConstants.ResponseStatusCode),
                //    GetValueFromEnvironment(environment, OwinConstants.ResponseReasonPhrase)));
                #endregion
                #region Stop Watch Format 2
                StopFormat = "Stop\t{0}\t{1}\t{2}\t{3}" + Environment.NewLine;
                #region Filter and Write
                isStatics = path.IndexOf("Statics");
                if (isStatics == -1)
                {
                    //WriteLog(string.Format(StopFormat, DateTime.Now.ToString(), RemoteIpAddress, method, path));
                }
                #endregion


                #endregion
                return t;
            });
        }

        /// <summary>
        /// Write Log Database
        /// </summary>
        /// <param name="content"></param>
        private static async void WriteLog(string content)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Statics");
            path += Path.Combine("\\" + DateTime.Now.ToShortDateString() + ".txt");
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    //string HeaderFormat = "Durum\t{0}\t{1}\t{2}\t{3}" + Environment.NewLine;
                    //await sw.WriteAsync(string.Format(HeaderFormat, "Zaman              ","Ip Adres ", "Method", "Yol"));
                    //await sw.WriteAsync(content);
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                await sw.WriteAsync(content);
            }
        }

        /// <summary>
        /// Database Insert Function
        /// </summary>
        /// <param name="content"></param>
        private static void WriteDatabase(string content)
        {
            //MsSql
            //MySql
            //Oracle
            //Xml
            //Save(content);
            Console.WriteLine(content);
        }
        
        /// <summary>
        /// Readind Database Log Text
        /// </summary>
        /// <returns></returns>
        public static List<Options> ReadLog()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Statics");
            path += Path.Combine("\\" + DateTime.Now.ToShortDateString() + ".txt");
            List<Options> LogData = new List<Options>();
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    //string HeaderFormat = "Durum\t{0}\t{1}\t{2}\t{3}" + Environment.NewLine;
                    //sw.WriteAsync(string.Format(HeaderFormat, "Zaman              ","Ip Adres ", "Method", "Yol"));
                }
            }
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] Line = s.Split(';');
                    LogData.Add(new Options { tarih = Line[0], ip = Line[1], path = Line[2] });
                }
            }
            return LogData;
        }

        /// <summary>
        /// Options Model
        /// </summary>
        public class Options
        {
            public string tarih { get; set; }
            public string ip { get; set; }
            public string path { get; set; }
        }
        
        /// <summary>
        /// Getting Response Variable
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetValueFromEnvironment(IDictionary<string, object> environment, string key)
		{
            object value;
            environment.TryGetValue(key, out value);
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }
    }
}