# LGC_NUnit
Automation Technical Assessment for Lets Get Checked using NUnit for API testing

Run all tests using : dotnet test
Use the following to generate the allure report : allure generate allure-results --clean -o allure-report
Use the following to open the allure report : allure open allure-report

Before running the tests ensure you have the following Nuget packages installed

using NUnit.Framework;
using RestSharp;
using System.Net;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

