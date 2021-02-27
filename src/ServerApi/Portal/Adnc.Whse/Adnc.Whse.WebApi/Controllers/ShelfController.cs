﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adnc.Whse.Application.Services;
using Adnc.Whse.Application.Dtos;
using Adnc.WebApi.Shared;
using Adnc.Infr.Common.Extensions;
using Adnc.Application.Shared.Dtos;

namespace Adnc.Whse.WebApi.Controllers
{
    /// <summary>
    /// 货架管理
    /// </summary>
    [Route("whse/shelfs")]
    [ApiController]
    public class ShelfController : AdncControllerBase
    {
        private readonly IWarehouseAppService _shelfSrv;

        public ShelfController(IWarehouseAppService shelfSrv)
        {
            _shelfSrv = shelfSrv;
        }

        /// <summary>
        /// 新建货架
        /// </summary>
        /// <param name="input"><see cref="WarehouseCreationDto"/></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<WarehouseDto>> CreateAsync([FromBody] WarehouseCreationDto input)
        {
            return await _shelfSrv.CreateAsync(input);
        }

        /// <summary>
        /// 分配货架给商品
        /// </summary>
        /// <returns></returns>
        [HttpPatch("{id}/product")]
        public async Task<ActionResult<WarehouseDto>> AllocateShelfToProductAsync([FromRoute] long id, [FromBody] WarehouseAllocateToProductDto input)
        {
            return await _shelfSrv.AllocateShelfToProductAsync(id, input);
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PageModelDto<WarehouseDto>> GetPagedAsync([FromQuery]WarehouseSearchDto search)
        {
            return await _shelfSrv.GetPagedAsync(search);
        }
    }
}