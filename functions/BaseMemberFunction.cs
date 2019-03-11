using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Models;
using ServerlessRepository;

public abstract class BaseMemberFunction
{
    protected async Task<Models.MemberData> GetMember(int id)
    {
        return await Task<Models.MemberData>.Factory.StartNew(()=>{
            return new MemberRepository().GetMember(id);
        });        
    }

    protected async Task<List<Models.MemberData>> GetAllMembers()
    {
        return await Task<List<Models.MemberData>>.Factory.StartNew(()=>{
            return new MemberRepository().GetAllMembers();
        });        
    }
}