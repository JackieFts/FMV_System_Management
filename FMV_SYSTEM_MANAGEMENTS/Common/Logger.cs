using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMV_SYSTEM_MANAGEMENTS
{
    public class Logger
    {
        private readonly log4net.ILog _Logger;

        public enum LogLevel : int
        {
            DEBUG = 0,
            INFO,
            WARN,
            ERROR,
            FATAL
        }

        public Logger()
        {
            log4net.GlobalContext.Properties["LogFileName"] = "System.log";
            log4net.Config.XmlConfigurator.Configure();
            _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void LogMsg(LogLevel i_LogLevel, /*string i_sLogMode,*/ string i_sMessage, params object[] i_Param)
        {
            string sLogFileName = "System.log";

            //switch (i_sLogMode)
            //{
            //    case "sendAPI":
            //        sLogFileName = "sendAPI.log";
            //        break;
            //    case "LogErr":
            //        sLogFileName = "Exception.log";
            //        break;
            //    case "LogInfo":
            //        sLogFileName = "InformationLog.log";
            //        break;
            //    default:
            //        break;
            //}

            log4net.GlobalContext.Properties["LogFileName"] = sLogFileName;
            log4net.Config.XmlConfigurator.Configure();

            switch (i_LogLevel)
            {
                case LogLevel.DEBUG:
                    _Logger.DebugFormat(i_sMessage, i_Param);
                    break;

                case LogLevel.INFO:
                    _Logger.InfoFormat(i_sMessage, i_Param);
                    break;

                case LogLevel.WARN:
                    _Logger.WarnFormat(i_sMessage, i_Param);
                    break;

                case LogLevel.ERROR:
                    _Logger.ErrorFormat(i_sMessage, i_Param);
                    break;

                case LogLevel.FATAL:
                    _Logger.FatalFormat(i_sMessage, i_Param);
                    break;

                default:
                    break;
            }
        }
    }
}
