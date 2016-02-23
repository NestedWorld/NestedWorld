using NestedWorld.Classes.ElementsGame.Monsters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.Network
{
    public class Network
    {
        public string Token { get; set; }

        public async Task<ReturnObject> Connect(string mail, string pass)
        {
            ReturnObject ReturnObject;

            Request.Auth.Login login = new Request.Auth.Login();
            login.SetParam(pass, mail);
            if (App.core.Offline)
                return new ReturnObject()
                {
                    Content = null,
                    ErrorCode = 0,
                    Message = string.Empty

                };
            try
            {
                JObject obj = await login.GetJsonAsync();
                Token = obj["token"].ToObject<string>();
                Debug.WriteLine("Token = " + Token);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = 0, Message = string.Empty };
            }
            catch (HttpRequestException HRException)
            {
                Debug.WriteLine(HRException);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = HRException.HResult, Message = "HttpRequestException : " + HRException.Message };
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Debug.WriteLine(jEx);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = jEx.HResult, Message = "JsonException : " + jEx.Message };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = ex.HResult, Message = "Exception : " + ex.Message };

            }
            return ReturnObject;
        }

        public async Task<ReturnObject> Logout()
        {
            ReturnObject ReturnObject;
            Request.Auth.Logout logout = new Request.Auth.Logout();
            logout.SetParam();
            if (App.core.Offline)
                return new ReturnObject()
                {
                    Content = null,
                    ErrorCode = 0,
                    Message = string.Empty

                };
            try
            {
                JObject obj = await logout.GetJsonAsync();
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = 0, Message = string.Empty };
            }
            catch (HttpRequestException HRException)
            {
                Debug.WriteLine(HRException);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = HRException.HResult, Message = "HttpRequestException : " + HRException.Message };
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Debug.WriteLine(jEx);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = jEx.HResult, Message = "JsonException : " + jEx.Message };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = ex.HResult, Message = "Exception : " + ex.Message };

            }
            return ReturnObject;
        }



        #region Monster
        public async Task<ReturnObject> GetMonster(int number = -1)
        {
            ReturnObject ReturnObject;

            MonsterList ml;

            Request.Monster.Monsters monsters = new Request.Monster.Monsters();
            monsters.SetParam();
            if (App.core.Offline)
                return new ReturnObject()
                {
                    Content = MonsterList.GetMonsterListFromJson(null, 30),
                    ErrorCode = 0,
                    Message = string.Empty

                };
            try
            {
                ml = MonsterList.GetMonsterListFromJson(await monsters.GetJsonAsync());
                ReturnObject = new ReturnObject() { Content = ml, ErrorCode = 0, Message = string.Empty };
            }
            catch (HttpRequestException HRException)
            {
                Debug.WriteLine(HRException);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = HRException.HResult, Message = "HttpRequestException : " + HRException.Message };
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Debug.WriteLine(jEx);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = jEx.HResult, Message = "JsonException : " + jEx.Message };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = ex.HResult, Message = "Exception : " + ex.Message };

            }
            return ReturnObject;
        }

        public async Task<ReturnObject> GetUserMonster()
        {
            ReturnObject ReturnObject;

            MonsterList ml;

            Request.Monster.UsersMonster monsters = new Request.Monster.UsersMonster();
            monsters.SetParam(Token);

            if (App.core.Offline)
                return new ReturnObject()
                {
                    Content = MonsterList.GetUserMonsterListFromJson(null, 12),
                    ErrorCode = 0,
                    Message = string.Empty

                };

            try
            {
                ml = MonsterList.GetUserMonsterListFromJson(await monsters.GetJsonAsync());
                ReturnObject = new ReturnObject() { Content = ml, ErrorCode = 0, Message = string.Empty };
            }
            catch (HttpRequestException HRException)
            {
                Debug.WriteLine(HRException);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = HRException.HResult, Message = "HttpRequestException : " + HRException.Message };
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Debug.WriteLine(jEx);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = jEx.HResult, Message = "JsonException : " + jEx.Message };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ReturnObject = new ReturnObject() { Content = null, ErrorCode = ex.HResult, Message = "Exception : " + ex.Message };

            }
            return ReturnObject;
        }

        #endregion
    }
}
