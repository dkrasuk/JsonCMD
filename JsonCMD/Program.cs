using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using JsonCMD.Response;
using System.IO;
using System.Threading;

namespace JsonCMD
{
    class Program
    {
        /// <summary>
        /// Выгружаем бренды автомобилей
        /// </summary>
        public static List<Request.BrandCar> brandCarList = new List<Request.BrandCar>();
        public static List<Response.BrandCar> brandCarListResponse = new List<Response.BrandCar>();

        public static string jsonResponse = null;

        public void GetBrand()
        {

            WebClient client = new WebClient();
            string valueJson = client.DownloadString("https://developers.ria.com/auto/categories/1/marks?api_key=Pqu4ZfbPPj9AtraazzTCStUXHKzgvKPDK9L6GZeG");
            brandCarList = JsonConvert.DeserializeObject<List<Request.BrandCar>>(valueJson);

            foreach (var item in brandCarList)
            {
                BrandCar BrandCar = new BrandCar();
                BrandCar.Value.Id = item.Value;
                BrandCar.Value.Name = item.Name;
                BrandCar.ValueId = item.Value;

                brandCarListResponse.Add(BrandCar);
            }

            jsonResponse = JsonConvert.SerializeObject(brandCarListResponse);
            File.AppendAllText(@"C:\jsonBrand.txt", jsonResponse, UTF32Encoding.Default);

        }


        /// <summary>
        /// Выгружаем модели автомобилей
        /// </summary>
        /// <param name="args"></param>

        public void GetModel()
        {
            List<RequestModel.ModelCar> modelCar = new List<RequestModel.ModelCar>();
            List<ResponseModel.ModelCar> modelCarResponse = new List<ResponseModel.ModelCar>();
            

            string jsonResponseModel = null;

            WebClient client = new WebClient();
            string valueJson = string.Empty;

            foreach (var item in brandCarList)
            {
               
                string temp = string.Empty;
                temp = client.DownloadString(string.Format("https://developers.ria.com/auto/categories/1/marks/{0}/models?api_key=Pqu4ZfbPPj9AtraazzTCStUXHKzgvKPDK9L6GZeG", item.Value));
                modelCar = JsonConvert.DeserializeObject<List<RequestModel.ModelCar>>(temp);

                foreach (var model in modelCar)
                {
                    ResponseModel.ModelCar ModelCar = new ResponseModel.ModelCar();

                    ModelCar.Value.Id = model.Value.ToString();
                    ModelCar.Value.Name = model.Name;
                    ModelCar.Value.Brand = item.Name;
                    ModelCar.ValueId = model.Value.ToString();
                    modelCarResponse.Add(ModelCar);
                    ModelCar = null;
                }
                Thread.Sleep(5000);

            }
            jsonResponseModel = JsonConvert.SerializeObject(modelCarResponse);
            File.AppendAllText(@"C:\jsonModel.txt", jsonResponseModel, UTF32Encoding.Default);


        }


        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.GetBrand();
          //  pr.GetModel();

        }



    }
}