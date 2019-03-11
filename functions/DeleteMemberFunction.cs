using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Models;

//[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ServerlessFunctions
{
    public class DeleteMemberFunction : BaseMemberFunction
    {      
        public DeleteMemberFunction()
        {        
        }
        
        public async Task<APIGatewayProxyResponse> Handle(APIGatewayProxyRequest request)
        {                  
             Console.WriteLine("In the Delete::handle()");                        
            var memberModel = JsonConvert.DeserializeObject<MemberData>(request.Body);
            if (memberModel == null) 
            {
                return new APIGatewayProxyResponse{StatusCode = 400};
            }
            Console.WriteLine("Member: " + memberModel.ToString());
            var result = await GetMember(memberModel.Id);
            
            // Simulate the delete request.  It does not really delete...

            return result == null ? 
                new APIGatewayProxyResponse {StatusCode = 404} : 
                new APIGatewayProxyResponse { StatusCode =  204 };
        }
    }
}