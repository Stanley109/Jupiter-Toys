using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver{

    class ExtentReportsHelper{
        private static ExtentHtmlReporter? _htmlreport;
        private static AventStack.ExtentReports.ExtentReports? _extent ;
        private static AventStack.ExtentReports.ExtentTest? _feature, _scenario, _step;

        public static void CreateNewReport(){
            _htmlreport =  new ExtentHtmlReporter(Base.BasePath+"\\Test Reports\\");
            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AttachReporter(_htmlreport);
        }

        public static void CreateFeatureReport(FeatureContext specflowContext)
        {
            if (_extent is not null) _feature = _extent.CreateTest(specflowContext.FeatureInfo.Title);
        }

        public static void CreateScenarioReport(ScenarioContext specflowContext)
        {
            if (_feature is not null) _scenario = _feature.CreateNode(specflowContext.ScenarioInfo.Title);
        }

        public static void CreateStepReport(ScenarioContext specflowContext)
        {
            if (_scenario is not null)
            { 
                _step = _scenario;
                if(specflowContext.TestError == null)
                {
                    _step.Log(Status.Pass,$"{specflowContext.StepContext.StepInfo.StepDefinitionType.ToString()} {specflowContext.StepContext.StepInfo.Text}");
                }
                else
                {
                    _step.Log(Status.Fail,$"{specflowContext.StepContext.StepInfo.StepDefinitionType.ToString()} {specflowContext.StepContext.StepInfo.Text}");
                    _step.Log(Status.Info,specflowContext.TestError.ToString());
                }
            }
        }

        public static void EndReport()
        {
            if (_extent is not null) _extent.Flush();
        }
        
    }
}