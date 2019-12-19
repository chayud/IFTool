using System;

namespace Utility
{
    public class Gm
    {
        #region "     Casting Data     "

        public static DateTime ToDateTimeAD(DateTime obj)
        {
            try
            {
                if (obj.Year > 2400)
                {
                    return new DateTime(obj.Year - 543, obj.Month, obj.Day, obj.Hour, obj.Minute, obj.Second);
                }

                return obj;
            }
            catch
            {
                return obj;
            }
        }

        public static DateTime? ToDateTimeAD(DateTime? obj)
        {
            try
            {
                if (obj.HasValue)
                {
                    DateTime dd = obj.Value;

                    if (obj.Value.Year > 2400)
                    {
                        return new DateTime(dd.Year - 543, dd.Month, dd.Day, dd.Hour, dd.Minute, dd.Second);
                    }

                    return obj;
                }               

                return obj;
            }
            catch
            {
                return obj;
            }
        }

        public static int ToInt(object obj)
        {
            try
            {
                int i = Convert.ToInt32(obj.ToString().Replace(",", ""));
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static long ToLong(object obj)
        {
            try
            {
                long i = Convert.ToInt64(obj.ToString().Replace(",", ""));
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static double ToDouble(object obj)
        {
            try
            {
                double i = Convert.ToDouble(obj.ToString().Replace(",", ""));
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static float ToFloat(object obj)
        {
            try
            {
                float i = (float)ToDouble(obj);
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ToDecimal(object obj)
        {
            try
            {
                decimal i = Convert.ToDecimal(obj.ToString().Replace(",", ""));
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static string ToCharacter(object obj)
        {
            try
            {
                if (obj == DBNull.Value || obj == null)
                    return "";

                return obj.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string ToCharacter(object obj, string Format)
        {
            try
            {
                if (obj == DBNull.Value || obj == null)
                    return "";

                return string.Format("{0:" + Format + "}", obj);
            }
            catch
            {
                return "";
            }
        }

        public static DateTime ToDateTime(object obj)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(obj);
                return dt;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static bool ToBoolean(object obj)
        {
            try
            {
                if ((obj == null || object.ReferenceEquals(obj, DBNull.Value)))
                {
                    return false;
                }

                return (obj.ToString().ToUpper() == "TRUE" || obj.ToString() == "1");
            }
            catch
            {
                return false;
            }
        }

        public static DateTime StringToDatetime(string strDate)
        {
            if (strDate.Length == 0)
                return DateTime.MinValue;

            string[] s = strDate.ToString().Split('/');

            int y = ToInt(s[2]);
            int m = ToInt(s[1]);
            int d = ToInt(s[0]);

            return new DateTime(y, m, d);
        }

        public static string DatetimeToString(DateTime dDate)
        {
            return string.Format("{0:00}/{1:00}/{2:0000}", dDate.Day, dDate.Month, dDate.Year); //((dDate.Year < 2500) ? dDate.Year + 543 : dDate.Year)
        }

        public static string DatetimeToStringLong(DateTime dDate)
        {
            return string.Format("{0:00}/{1:00}/{2:0000} {3:00}:{4:00}:{5:00}", dDate.Day, dDate.Month, dDate.Year, dDate.Hour, dDate.Minute, dDate.Second);
        }

        public static long DatetimeToTicks(DateTime dDate)
        {
            return dDate.Ticks;
        }

        public static string DatetimeToTicksString(DateTime dDate)
        {
            return ToCharacter(dDate.Ticks);
        }

        public static DateTime TicksToDatetime(long ticks)
        {
            return new DateTime(ticks); ;
        }

        public static DateTime TicksStringToDatetime(string ticks)
        {
            return new DateTime(ToLong(ticks));
        }

        public static string DateToSQLString(DateTime dDate)
        {
            return string.Format("{0:0000}-{1:00}-{2:00}", dDate.Year, dDate.Month, dDate.Day);
        }

        public static bool IsNumeric(string strText)
        {
            try
            {
                if (strText == null)
                    strText = "";

                if (strText.Length > 0)
                {
                    double dummyOut = new double();
                    System.Globalization.CultureInfo cultureInfo =
                        new System.Globalization.CultureInfo("en-US", true);

                    return Double.TryParse(strText, System.Globalization.NumberStyles.Any,
                        cultureInfo.NumberFormat, out dummyOut);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string ToNumericStr(object obj)
        {
            try
            {
                if ((obj == null || object.ReferenceEquals(obj, DBNull.Value)))
                {
                    return "";
                }

                return string.Format("{0:N2}", obj);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string ToIntStr(object obj)
        {
            try
            {
                if ((obj == null || object.ReferenceEquals(obj, DBNull.Value)))
                {
                    return "";
                }

                return string.Format("{0:N0}", obj);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string DBText(object obj)
        {
            try
            {
                if ((obj == null || object.ReferenceEquals(obj, DBNull.Value)))
                {
                    return "";
                }

                return obj.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string ToText(object obj)
        {
            return DBText(obj);
        }

        public static bool IsInt(object obj)
        {
            if ((obj == null || object.ReferenceEquals(obj, DBNull.Value)))
            {
                return false;
            }

            int n = 0;
            return int.TryParse(obj.ToString(), System.Globalization.NumberStyles.Integer | System.Globalization.NumberStyles.AllowThousands, null, out n);
        }

        public static bool IsDouble(object obj)
        {
            if ((obj == null || object.ReferenceEquals(obj, DBNull.Value)))
            {
                return false;
            }

            double n = 0;
            return double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Number, null, out n);
        }

        //public static string MD5(string strKey)
        //{
        //    MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();

        //    byte[] data = System.Text.Encoding.ASCII.GetBytes(strKey);
        //    byte[] encryptedData = md5Provider.ComputeHash(data);

        //    return Convert.ToBase64String(encryptedData);
        //}

        public static double Round(double val)
        {
            return Math.Round(val, 0, MidpointRounding.AwayFromZero);
        }

        public static object ToDateTimeParam(DateTime d)
        {
            if ((d > DateTime.MinValue))
            {
                return d;
            }
            else
            {
                return DBNull.Value;
            }
        }

        public static object ToIntParam(int i)
        {
            if ((i > int.MinValue))
            {
                return i;
            }
            else
            {
                return DBNull.Value;
            }
        }

        public static object ToDoubleParam(double i)
        {
            if ((i > double.MinValue))
            {
                return i;
            }
            else
            {
                return DBNull.Value;
            }
        }

        public static object ToStringParam(string s)
        {
            if ((string.IsNullOrEmpty(s) || s == null))
            {
                return DBNull.Value;
            }
            else
            {
                return s;
            }
        }

        #endregion

        public static bool CheckString(string val)
        {
            string str = "!@#$%^&*()_+=-0987654321[]\\|{}\":/?<>"; //ตัวอักษรที่ไม่ต้องการให้มี

            for (int i = 0; i < str.Length; i++)
            {
                string chr = str.Substring(i, 1);

                if (val.IndexOf(chr) != -1)
                    return true;
            }

            return false;
        }

        public static bool ValidatePersonID(string PersonID)
        {
            // ตรวจสอบว่าเป็นตัวเลขทั้งหมด      
            if (Gm.IsNumeric(PersonID) == false) return false;
            //ตรวจสอบว่ามี 13 ตัวอักษรหรือไม่
            if (PersonID.Trim().Length != 13) return false;

            int sumValue = 0;
            for (int i = 0; i < PersonID.Length - 1; i++)
                sumValue += Gm.ToInt(PersonID[i]) * (13 - i);

            int v = (11 - (sumValue % 11)) % 10;
            return PersonID[12].ToString() == v.ToString();
        }

        public static bool IsValidateThaiNationality(string str)
        {
            if (str.ToLower() == "ไทย" || str.ToLower() == "ประเทศไทย" || str.ToLower() == "thai" || str.ToLower() == "thailand")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
