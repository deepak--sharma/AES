using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Configuration;
using System.Globalization;

namespace AES.SolutionFramework
{
    public class GeneralUtility
    {

        #region TO CHECK WHEATHER AN OBJECT IS AN INTEGER OR NOT

        public static bool IsInteger(object obj)
        {
            int i = 0;
            try
            {
                i = int.Parse(obj.ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool IsLong(object obj)
        {
            long i = 0;
            try
            {
                i = Convert.ToInt64(obj);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool IsNumeric(object obj)
        {
            bool check = true;
            string strNumeric = obj.ToString();
            foreach (char c in strNumeric)
            {
                if (!Char.IsDigit(c))
                {
                    check = false;
                }
            }
            return check;
        }

        #endregion

        #region TO CHECK WHEATHER AN OBJECT IS AN DECIMAL OR NOT

        public static bool IsDecimal(object obj)
        {
            decimal i = 0;
            try
            {
                i = decimal.Parse(obj.ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region TO CHECK WHEATHER AN OBJECT IS AN DOUBLE OR NOT

        public static bool IsDouble(object obj)
        {
            double i = 0;
            try
            {
                i = double.Parse(obj.ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region TO CHECK WHEATHER AN OBJECT IS BOOLEAN OR NOT

        public static bool IsBoolean(object obj)
        {
            try
            {
                obj = bool.Parse(obj.ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region TO CHECK WHEATHER AN OBJECT IS NULL OR NOT

        public static bool IsNull(object obj)
        {
            if (obj == null)
                return true;
            else
                return false;
        }

        #endregion

        #region TO CHECK WHEATHER AN EMAIL ADDRESS IS VALID OR NOT

        public static bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            // Confirm that the e-mail address string is not empty.
            if (emailAddress.Length == 0)
            {
                errorMessage = "e-mail address is required.";
                return false;
            }

            // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";

                    return true;
                }
            }

            errorMessage = "e-mail address must be valid e-mail address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }

        #endregion

        #region FUNCTIONS TO MANUPLATE DATE TIME

        public static DateTime CurrentDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }

        public static bool IsDateTime(object obj)
        {
            try
            {
                obj = Convert.ToDateTime(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidDate(string strDate)
        {
            try
            {
                DateTime.ParseExact(strDate, "dd/mm/yyyy", null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime FormatDate(string formatString)
        {
            string strDateTime = formatString.Trim();
            string[] tempStr = strDateTime.Split('-');
            DateTime formatedDate = DateTime.MinValue;
            if (tempStr[0].Trim().Trim().Length == 1)
            {
                strDateTime = strDateTime.Insert(0, "0");
            }
            if (tempStr[1].Trim().Trim().Length == 1)
            {
                strDateTime = strDateTime.Insert(3, "0");
            }
            strDateTime = strDateTime.Remove(16, 3);
            try
            {
                formatedDate = DateTime.ParseExact(strDateTime, "dd-MM-yyyy hh:mm tt", null);
            }
            catch (Exception ex)
            {
                throw ex;
                //send wrong fromat date
            }
            return formatedDate;

        }

        public static string ToStandardDate(object objDate)
        {
            DateTime parsedDate = Convert.ToDateTime(objDate);
            return parsedDate.ToString("dd-MMM-yyyy");
        }

        public static int GetTotalMonths(DateTime objDate, DateTime subtractDate)
        {
            int totalYear, totalMonth;

            totalYear = objDate.Year - subtractDate.Year;

            if (totalYear < 0)
            {
                throw new Exception("Subtract date is greater than given date range");
                return -1;
            }
            totalMonth = totalYear * 12;

            totalMonth += (objDate.Month - subtractDate.Month);

            if (totalMonth < 0)
            {
                throw new Exception("Subtract date is greater than given date range");
                return -1;
            }
            return totalMonth;
        }

        public static DateTime DDMMYY_MMDDYY(string DDMMYY_Format)
        {

            DateTime convertedDate = DateTime.Parse(DDMMYY_Format.ToString(), new CultureInfo("en-CA", true), DateTimeStyles.NoCurrentDateDefault);
            return convertedDate;
        }

        public static DateTime MMDDYY_DDMMYY(string MMDDYY_Format)
        {            
            DateTime convertedDate = DateTime.Parse(MMDDYY_Format.ToString(), new CultureInfo("en-CA", true), DateTimeStyles.NoCurrentDateDefault);
            return convertedDate;
        }

        #endregion

    }

    public class CommonConstant
    {
        public const int SUCCEED = 1;
        public const int FAIL = -1;
        public const int INVALID = -11;
        public const int DUPLICATE = 0;
        public const int DEFAULT_ID = -99;
    }

    public class Encryption
    {
        #region Class Constructor

        public Encryption()
        {

        }

        #endregion

        #region Class Static Methods

        /// <summary>
        /// This Function is used to Generate Key      
        /// </summary>
        /// <returns>Byte Array type that hold the Key</returns>
        private static byte[] GenerateKey()
        {
            //TripleDESCryptoServiceProvider tDes = new TripleDESCryptoServiceProvider();
            //tDes.GenerateKey();
            //_DecryptionKey = tDes.Key;
            return new byte[] { 137, 241, 181, 79, 71, 224, 162, 36, 42, 198, 36, 4, 89, 100, 242, 89, 49, 180, 203, 213, 76, 230, 95, 37 };
        }

        /// <summary>
        /// This Function is used to Encrypt the password        
        /// </summary>
        /// <param name="strPassword">String Type Parameter that hold the password in Plain Text</param>
        /// <returns>String Type Parameter that hold the password in Encrypted Form</returns>
        public static string EncryptPassword(string strPassword)
        {
            byte[] _DecryptionKey = GenerateKey();

            System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();
            byte[] uePassword = ue.GetBytes(strPassword);
            byte[] RetVal = null;

            // TripleDes Encrypt format
            TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();

            tripleDes.Key = _DecryptionKey;
            tripleDes.IV = new byte[8];

            MemoryStream mStreamEnc = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(mStreamEnc, tripleDes.CreateEncryptor(), CryptoStreamMode.Write);

            cryptoStream.Write(uePassword, 0, uePassword.Length);
            cryptoStream.FlushFinalBlock();
            RetVal = mStreamEnc.ToArray();
            cryptoStream.Close();

            return Convert.ToBase64String(RetVal, 0, RetVal.GetLength(0));

        }

        /// <summary>
        /// This Function is used to Decrypt the password        ///
        /// </summary>
        /// <param name="strPWD">String Type parameter that holds the User Password in Encrypted Form</param>
        /// <returns>String Type Parameter that hold the password in Plain Text</returns>
        public static string DecryptPassword(string strPWD)
        {
            byte[] _DecryptionKey = GenerateKey();

            byte[] StoredPassword = Convert.FromBase64String(strPWD);

            System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();
            string RetVal = null;

            TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();

            tripleDes.Key = _DecryptionKey;
            tripleDes.IV = new byte[8];

            CryptoStream cryptoStream = new CryptoStream(new MemoryStream(StoredPassword), tripleDes.CreateDecryptor(), CryptoStreamMode.Read);
            MemoryStream msPasswordDec = new MemoryStream();
            int BytesRead = 0;

            byte[] Buffer = new byte[32];
            while ((BytesRead = cryptoStream.Read(Buffer, 0, 32)) > 0)
            {
                msPasswordDec.Write(Buffer, 0, BytesRead);
            }
            cryptoStream.Close();

            RetVal = ue.GetString(msPasswordDec.ToArray());
            msPasswordDec.Close();

            return RetVal;
        }

        #endregion
    }

    public class RandomPassword
    {
        #region DECLARATION

        private static int DEFAULT_MIN_PASSWORD_LENGTH = 8;
        private static int DEFAULT_MAX_PASSWORD_LENGTH = 10;
        private static string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        private static string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        private static string PASSWORD_CHARS_NUMERIC = "23456789";
        private static string PASSWORD_CHARS_SPECIAL = "?@#";


        #endregion

        #region STATIC METHODS

        public static string Generate()
        {
            return Generate(DEFAULT_MIN_PASSWORD_LENGTH,
                            DEFAULT_MAX_PASSWORD_LENGTH);
        }

        public static string Generate(int length)
        {
            return Generate(length, length);
        }

        public static string Generate(int minLength, int maxLength)
        {
            if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
                return null;

            char[][] charGroups = new char[][] 
                                            {
                                                PASSWORD_CHARS_LCASE.ToCharArray(),
                                                PASSWORD_CHARS_UCASE.ToCharArray(),
                                                PASSWORD_CHARS_NUMERIC.ToCharArray(),
                                                PASSWORD_CHARS_SPECIAL.ToCharArray()
                                            };


            int[] charsLeftInGroup = new int[charGroups.Length];
            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;
            int[] leftGroupsOrder = new int[charGroups.Length];
            for (int i = 0; i < leftGroupsOrder.Length; i++)
                leftGroupsOrder[i] = i;
            byte[] randomBytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);
            int seed = (randomBytes[0] & 0x7f) << 24 |
                        randomBytes[1] << 16 |
                        randomBytes[2] << 8 |
                        randomBytes[3];
            Random random = new Random(seed);


            char[] password = null;


            if (minLength < maxLength)
                password = new char[random.Next(minLength, maxLength + 1)];
            else
                password = new char[minLength];


            int nextCharIdx;


            int nextGroupIdx;


            int nextLeftGroupsOrderIdx;


            int lastCharIdx;


            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;


            for (int i = 0; i < password.Length; i++)
            {
                if (lastLeftGroupsOrderIdx == 0)
                    nextLeftGroupsOrderIdx = 0;
                else
                    nextLeftGroupsOrderIdx = random.Next(0,
                                                         lastLeftGroupsOrderIdx);


                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];


                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;


                if (lastCharIdx == 0)
                    nextCharIdx = 0;
                else
                    nextCharIdx = random.Next(0, lastCharIdx + 1);


                password[i] = charGroups[nextGroupIdx][nextCharIdx];


                if (lastCharIdx == 0)
                    charsLeftInGroup[nextGroupIdx] =
                                              charGroups[nextGroupIdx].Length;

                else
                {

                    if (lastCharIdx != nextCharIdx)
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] =
                                    charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }

                    charsLeftInGroup[nextGroupIdx]--;
                }


                if (lastLeftGroupsOrderIdx == 0)
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

                else
                {

                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] =
                                    leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }

                    lastLeftGroupsOrderIdx--;
                }
            }
            return new string(password);
        }

        #endregion
    }

    public class HandlingMail
    {
        #region DECLARATIONS AND ASSINMENTS

        private static string senderID, senderName, senderPassword;
        private static string strHostName;
        private static int portNumber;

        #endregion

        #region Initialize Variables

        private static void InitializeVariables()
        {
            strHostName = ConfigurationManager.AppSettings["HostName"].ToString();
            senderID = ConfigurationManager.AppSettings["SenderId"].ToString();
            //senderPassword = ConfigurationManager.AppSettings["SenderPassword"].ToString();
            senderName = ConfigurationManager.AppSettings["SenderName"].ToString();
            portNumber = Convert.ToInt32(ConfigurationManager.AppSettings["PortNumber"]);

        }

        #endregion

        #region Class Static Methods

        public static bool SendNewPasswordMail(string recepientID, string recepientName, string password)
        {
            bool mailSent = false;
            string strMessageSubject, strMessageBody;
            strMessageSubject = ConfigurationManager.AppSettings["NewPasswordMessageSubject"].ToString();
            strMessageBody = ConfigurationManager.AppSettings["NewPasswordMessageBody"].ToString();

            mailSent = Sendmail(recepientID, recepientName, password, strMessageSubject, strMessageBody);
            return mailSent;
        }

        public static bool SendLostPasswordMail(string recepientID, string recepientName, string password)
        {
            bool mailSent = false;
            string strMessageSubject, strMessageBody;
            strMessageSubject = ConfigurationManager.AppSettings["LostPasswordMessageSubject"].ToString();
            strMessageBody = ConfigurationManager.AppSettings["LostPasswordMessageBody"].ToString();

            mailSent = Sendmail(recepientID, recepientName, password, strMessageSubject, strMessageBody);
            return mailSent;
        }

        private static bool Sendmail(string recepientID, string recepientName, string password, string strMessageSubject, string strMessageBody)
        {
            try
            {
                InitializeVariables();

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(senderID, senderName);
                msg.To.Add(recepientID);
                msg.Subject = strMessageSubject;
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = "User ID= " + recepientName;
                msg.Body += "\nPassword= " + password;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = false;

                SmtpClient client = new SmtpClient();
                client.Host = strHostName;
                client.Port = portNumber;

                client.Send(msg);
            }
            catch (SmtpException ex)
            {
                return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        //private static void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        //{
        //-----------------------------------------------------
        //client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
        //    object userState = msg;
        //-----------------------------------------------------
        //    MailMessage mail = (MailMessage)e.UserState;
        //    string subject = mail.Subject;

        //    if (e.Cancelled)
        //    {
        //        string cancelled = string.Format("[{0}] Send canceled.", subject);
        //    }
        //    if (e.Error != null)
        //    {
        //        string error = String.Format("[{0}] {1}", subject, e.Error.ToString());
        //    }

        //}

        #endregion

    }

}


