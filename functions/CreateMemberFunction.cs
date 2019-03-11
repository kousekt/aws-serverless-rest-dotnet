using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Models;

/*
You can use this as the body of a test request
{
    "id":1,
    "firstName":"TestFirst",
    "lastName":"TestLast",
    "title":"My Title",
    "age":1
}
*/
namespace ServerlessFunctions
{
    public class CreateMemberFunction : BaseMemberFunction
    {      
        public CreateMemberFunction()
        {        
        }
        
        public async Task<APIGatewayProxyResponse> Handle(APIGatewayProxyRequest request)
        {      
            Console.WriteLine("In the CreateMemberFunction::handle()");                        
            var memberModel = JsonConvert.DeserializeObject<MemberData>(request.Body);
            if (memberModel == null) 
            {
                return new APIGatewayProxyResponse{StatusCode = 400};
            }
            Console.WriteLine("Member: " + memberModel.ToString());
            var result = await GetMember(memberModel.Id);
            if (result != null)
            {
                // it exists so we will throw a conflict
                return new APIGatewayProxyResponse{StatusCode = 409};
            }
            // Normally we'd send them a link to the resource...
            return new APIGatewayProxyResponse {StatusCode = 201, Body = JsonConvert.SerializeObject(memberModel)};
        }
    }
}