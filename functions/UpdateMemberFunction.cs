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
    public class UpdateMemberFunction : BaseMemberFunction
    {      
        public UpdateMemberFunction()
        {        
        }
        
        public async Task<APIGatewayProxyResponse> Handle(APIGatewayProxyRequest request)
        {
            Console.WriteLine("In the UpdateMemberFunction::handle()");                        
            var memberModel = JsonConvert.DeserializeObject<MemberData>(request.Body);
            if (memberModel == null) 
            {
                return new APIGatewayProxyResponse{StatusCode = 400};
            }
            Console.WriteLine("Member: " + memberModel.ToString());
            var result = await GetMember(memberModel.Id);
            if (result == null)
            {
                // it does not exist so we'll throw a 404
                return new APIGatewayProxyResponse{StatusCode = 404};
            }
            return new APIGatewayProxyResponse {StatusCode = 200, Body = JsonConvert.SerializeObject(memberModel)};
        }
    }
}