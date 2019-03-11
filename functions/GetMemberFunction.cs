using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Models;
using ServerlessRepository;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ServerlessFunctions
{
    public class GetMemberFunction : BaseMemberFunction
    {      
        public GetMemberFunction()
        {        
        }
        
        public async Task<APIGatewayProxyResponse> Handle(APIGatewayProxyRequest request)
        {                  
            if (request.PathParameters["id"] == null)
            {
                return new APIGatewayProxyResponse {StatusCode = 400, Body = "Missing ID"};
            }
            var id = Convert.ToInt32(request.PathParameters["id"].ToString());

            Console.WriteLine("Handle GetMember Request for MemberId = " + id);

            // Simulate some sort of "DB retrieval" for that member
                
            var result = await GetMember(id);

            return result == null ? 
                new APIGatewayProxyResponse {StatusCode = 404} : 
                new APIGatewayProxyResponse { StatusCode =  200,  Body = JsonConvert.SerializeObject(result)};
        }
    }
}