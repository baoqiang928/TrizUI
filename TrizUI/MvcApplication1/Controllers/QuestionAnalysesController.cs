using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Triz.BLL;
using Triz.Model;

namespace MvcApplication1.Controllers
{
    public class QuestionAnalysesController : ApiController
    {
        // GET api/QuestionAnalyses/5
        public QuestionAnalyseInfo Get(string id)
        {
            return new QuestionAnalyseLogic().GetByProjectID(id);
        }

        // GET api/QuestionAnalyses
        public object Get([FromUri]string IdealResolution1, int currentPage, int itemsPerPage)
        {
            int TotalItems = 0;
            int PagesLength = 0;
            List<QuestionAnalyseInfo> QuestionAnalyseInfoList = new QuestionAnalyseLogic().Query(IdealResolution1, currentPage, itemsPerPage, ref TotalItems,ref PagesLength);
            return new
            {
                TotalItems = TotalItems,
                PagesLength = PagesLength,
                Results = QuestionAnalyseInfoList
            };
        }

        // POST api/QuestionAnalyses
        public void Post([FromBody]QuestionAnalyseInfo QuestionAnalyseInfo)
        {
            new QuestionAnalyseLogic().SaveQuestionAnalyse(QuestionAnalyseInfo);
        }

        public void Put([FromBody]QuestionAnalyseInfo QuestionAnalyseInfo)
        {
            new QuestionAnalyseLogic().SaveQuestionAnalyse(QuestionAnalyseInfo);
        }

        // DELETE api/QuestionAnalyses/5
        public void Delete(int id)
        {
            new QuestionAnalyseLogic().DeleteQuestionAnalyse(id);
        }

        // DELETE api/QuestionAnalyses/5
        public void Delete(string ids)
        {
            new QuestionAnalyseLogic().DeleteQuestionAnalyse(ids);
        }

    }
}


