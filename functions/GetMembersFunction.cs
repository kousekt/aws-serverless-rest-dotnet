using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Models;
using ServerlessRepository;

namespace ServerlessFunctions
{
    public class GetMembersFunction : BaseMemberFunction
    {      
        public GetMembersFunction()
        {        
        }
        
        public async Task<APIGatewayProxyResponse> Handle(APIGatewayProxyRequest request)
        {                             
            // Simulate some sort of "DB retrieval" for all members
                
            var result = await GetAllMembers();

            return result == null ? 
                new APIGatewayProxyResponse {StatusCode = 404} : 
                new APIGatewayProxyResponse { StatusCode =  200,  Body = JsonConvert.SerializeObject(result)};
        }
    }
}