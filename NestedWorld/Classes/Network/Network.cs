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

        public async Task<string> Connect(string mail, string pass)
        {
            string returnString = string.Empty;
            Request.Auth.Login login = new Request.Auth.Login();
            login.SetParam(pass, mail);

            try
            {
                JObject obj = await login.GetJsonAsync();
                Token = obj["token"].ToObject<string>();
                Debug.WriteLine("Token = " + Token);
            }
            catch (HttpRequestException HRException)
            {
                Debug.WriteLine(HRException);
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Debug.WriteLine(jEx);
                returnString = "Json";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                returnString = "UnknowError";
            }

            return returnString;
        }

        public async Task<string> GetMonter(MonsterList ml)
        {
            string ReturnString = string.Empty;

            Request.Monster.Monsters monsters = new Request.Monster.Monsters();
            monsters.SetParam();

            try
            {
                JObject obj = await monsters.GetJsonAsync();
                JArray Array = obj["monsters"].ToObject<JArray>();

                int i = 1;
                foreach (JObject monster in Array)
                {
                    ml.Add(new UserMonster(new Monster(monster["name"].ToObject<string>(), ElementsGame.TypeEnum.DIRT, "ms-appx:///Assets/default_monster.png", i), 3));
                    i++;
                }

                Debug.WriteLine(obj);
            }
            catch (HttpRequestException HRException)
            {
                Debug.WriteLine(HRException);
                ReturnString = HRException.Message;
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Debug.WriteLine(jEx);
                ReturnString = jEx.Message;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                ReturnString = "UnknowError";
            }

            return ReturnString;
        }

        /* public async Task<ErrorNetworkCode> GetMonster()
         {

         }*/
    }
}
