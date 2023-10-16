﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.WebApi.Utility._MD5;
using MyBlog.WebApi.Utility.ApiResult;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterInfoController : ControllerBase
    {
        private readonly IWriterInfoService _iWriterInfoService;
        public WriterInfoController(IWriterInfoService iWriterInfoService)
        {
            _iWriterInfoService = iWriterInfoService;
        }
        [HttpPost("Create")]
        public async Task<ApiResult> Create(string name, string username, string userpwd)
        {
            //数据校验
            WriterInfo writer = new WriterInfo
            {
                Name = name,
                //加密密码
                UserPwd = MD5Helper.MD5Encrypt32(userpwd),
                UserName = username
            };
            //判断数据库中是否已经存在账号跟要添加的账号相同的数据
            var oldWriter = await _iWriterInfoService.FindAsync(c => c.UserName == username);
            if (oldWriter != null)
            {
                return ApiResultHelper.Error("账号已存在");
            }
            bool b = await _iWriterInfoService.CreateAsync(writer);
            if (!b)
            {
                return ApiResultHelper.Error("添加失败");
            }

            return ApiResultHelper.Success(writer);
        }
        [HttpPut("Edit")]
        public async Task<ApiResult> Edit(string name)
        {
            int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
            //TODO
            return ApiResultHelper.Error("");
        }
    }
}
