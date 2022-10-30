using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;

namespace Homework
{
    public class APITests
    {
        [Test, Order(0)]
        public void GetEmployeesLessThan30()
        {
            //Arrange
            int count = 0, i=0;
            var restClient = new RestClient("https://dummy.restapiexample.com/api/v1");
            var restRequest = new RestRequest("/employees", Method.Get);
            
            //Act
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            var employees = JsonConvert.DeserializeObject<Rootobject>(content);
            for(i = 0; i < employees.data.Length; i++)
            {
                if (employees.data[i].employee_age > 30)
                {
                    count++;
                }
            }

            //Assert
            Assert.AreEqual(count, 16);
        }

        [Test, Order(1)]
        public void AddEmployeeSuccessfullyWithAgeOver30()
        {
            //Arrange
            var restClient = new RestClient("http://dummy.restapiexample.com/api/v1");
            var age = "31";
            var restRequest = new RestRequest($"/create?age={age}", Method.Post);

            //Act
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            var employees = JsonConvert.DeserializeObject<RootObjectPost>(content);

            //Assert
            Assert.AreEqual(employees.status, "success");
        }

        [Test, Order(2)]
        public void UpdateAllEmployees()
        {
            //Arrange
            var restClient = new RestClient("http://dummy.restapiexample.com/api/v1");
            var name = "Dzmitry";
            var salary = 1200;
            var age = 28;
            var restRequest = new RestRequest($"update/{{ID}}?name={name}&salary={salary}&age={age}", Method.Put);
            
            //Act
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = restClient.Execute(restRequest);
            var content = response.Content;

            var employees = JsonConvert.DeserializeObject<RootObjectPut>(content);

            //Assert
            Assert.AreEqual(employees.status, "success");
        }
    }
 }
