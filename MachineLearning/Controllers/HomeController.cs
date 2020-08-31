using MachineLearning.Models;
using Microsoft.ML;
using System;
using System.IO;
using System.Web.Mvc;

namespace MachineLearning.Controllers
{
    public class HomeController : Controller
    {
        private string _modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data/MovieRecommendationModel.zip");
        public ActionResult Index()
        {
            return View(new MovieModel());
        }

        [HttpPost]
        public ActionResult Index(MovieModel model)
        {
            MLContext mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(_modelPath, out _);
            var predEngine = mlContext.Model.CreatePredictionEngine<MovieModel, PredictionModel>(mlModel);
            PredictionModel predictionResult = predEngine.Predict(model);

            model.IsRecommended = predictionResult.Score > 3.5;
            model.Ratings = Math.Round(predictionResult.Score, 1);
            return View(model);
        }
    }
}