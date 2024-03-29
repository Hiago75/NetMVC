﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMVC.Data;
using NetMVC.Models;
using Microsoft.EntityFrameworkCore;
using NetMVC.Services.Exceptions;

namespace NetMVC.Services
{
    public class SellerService
    {
        private readonly NetMVCContext _context;

        public SellerService(NetMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
            
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegretyException("Não é possivel deletar o(a) vendedor(a) em questão por que este(a) possui vendas");
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            if (! await _context.Seller.AnyAsync(x => x.Id == obj.Id))
                throw new NotFoundException("ID não encontrado");
            
            try { 
            _context.Update(obj);
            await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
