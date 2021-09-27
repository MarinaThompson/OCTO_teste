using desafio_OCTO.Models;
using desafio_OCTO.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_OCTO.Controllers
{
    public class ClientesController : Controller
    {
        private readonly DbContexto _context;

        public ClientesController(DbContexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pessoasfisicas = _context.ClientePessoaFisica.Include("Enderecos").Include("Contatos").ToList();
            var pessoasjuridicas = _context.ClientePessoaJuridica.Include("Enderecos").Include("Contatos").ToList();

            var clientesViewModel = new ClientesViewModel
            {
                PessoasFisicas = pessoasfisicas.ToList(),
                PessoasJuridicas = pessoasjuridicas.ToList()
            };
            return View(clientesViewModel);
        }

        // GET: Clientes/CreatePf
        public IActionResult CreatePf()
        {
            return View();
        }

        // GET: Clientes/CreatePj
        public IActionResult CreatePj()
        {
            return View();
        }

        //GET: Clientes/DetailsPj/5
        public async Task<IActionResult> DetailsPf(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var pf = await _context.ClientePessoaFisica
                .Include(c => c.Contatos)
                .Include(e => e.Enderecos)
                .FirstOrDefaultAsync(cpf => cpf.ID == id);
            
            if(pf == null)
            {
                return NotFound();
            }
            return View(pf);
        }

        //GET: Clientes/DetailsPj/5
        public async Task<IActionResult> DetailsPj(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var pj = await _context.ClientePessoaJuridica
                .Include(c => c.Contatos)
                .Include(e => e.Enderecos)
                .FirstOrDefaultAsync(cpj => cpj.ID == id);

            if(pj == null)
            {
                return NotFound();
            }
            return View(pj);
        }

        //POST: Clientes/CreatePf
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePf(PessoaFisica model)
        {
            try
            {
                if (ModelState.IsValid)
                {                
                    var pf = new PessoaFisica
                    {
                        Nome = model.Nome,
                        EstadoCivil = model.EstadoCivil,
                        DataNascimento = model.DataNascimento,
                        Profissao = model.Profissao,
                        CPF = model.CPF,
                        RG = model.RG,
                        Enderecos = new List<Endereco>(),    
                        Contatos = new List<Contato>()
                    };

                    foreach (var contato in model.Contatos)
                    {
                        pf.Contatos.Add(contato);
                    }

                    foreach (var endereco in model.Enderecos)
                    {
                        pf.Enderecos.Add(endereco);
                    }

                    _context.Add(pf);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
           catch(DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("", "Não foi possível realizar essa operação");
            }
            return View(model);
        }   

        //POST: Clientes/CreatePj
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePj(PessoaJuridica model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pj = new PessoaJuridica
                    {
                        NomeFantasia = model.NomeFantasia,
                        RazaoSocial = model.RazaoSocial,
                        DataAbertura = model.DataAbertura,
                        CNPJ = model.CNPJ,                        
                        Enderecos = new List<Endereco>(),
                        Contatos = new List<Contato>()
                    };

                    foreach (var contato in model.Contatos)
                    {
                        pj.Contatos.Add(contato);
                    }

                    foreach (var endereco in model.Enderecos)
                    {
                        pj.Enderecos.Add(endereco);
                    }

                    _context.Add(pj);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e);
                ModelState.AddModelError("", "Não foi possível realizar essa operação");
            }
            return View(model);
        }

        // GET: Clientes/EditPj/5
        public async Task<IActionResult> EditPj(int? id)
        {
            if(id == null)
             {
                    return NotFound();
             }

            var pj = await _context.ClientePessoaJuridica
                .Include(c => c.Contatos)
                .Include(e => e.Enderecos)
                .FirstOrDefaultAsync(cpj => cpj.ID == id);

            if(pj == null)
            {
                return NotFound();
            }
            return View(pj);
        }

        //POST: Clientes/EditPj/5
        [HttpPost, ActionName("EditPj")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPostPj(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pjToUpdate = await _context.ClientePessoaJuridica
                            .Include("Enderecos")
                            .Include("Contatos")
                            .FirstOrDefaultAsync(pj => pj.ID == id);
            if (await TryUpdateModelAsync<PessoaJuridica>(
                pjToUpdate,
                "",
                pj => pj.RazaoSocial, pj => pj.DataAbertura, pj => pj.NomeFantasia, pj => pj.CNPJ, pj => pj.Contatos, pj => pj.Enderecos))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex);
                    ModelState.AddModelError("", "Não foi possível realizar essa operação");
                }
            }
            return View(pjToUpdate);
        }

        // GET: Clientes/EditPf/5
        public async Task<IActionResult> EditPf(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pf = await _context.ClientePessoaFisica
                .Include(c => c.Contatos)
                .Include(e => e.Enderecos)
                .FirstOrDefaultAsync(cpf => cpf.ID == id);

            if (pf == null)
            {
                return NotFound();
            }
            return View(pf);
        }


        //POST: Clientes/EditPf/5
        [HttpPost, ActionName("EditPf")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPostPf(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfToUpdate = await _context.ClientePessoaFisica
                            .Include("Enderecos")
                            .Include("Contatos")
                            .FirstOrDefaultAsync(pf => pf.ID == id);
            if (await TryUpdateModelAsync<PessoaFisica>(
                pfToUpdate,
                "",
                cpf => cpf.Nome, cpf => cpf.Profissao, cpf => cpf.DataNascimento, cpf => cpf.EstadoCivil, cpf => cpf.CPF, cpf => cpf.RG, cpf => cpf.Enderecos, cpf => cpf.Contatos))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex);
                    ModelState.AddModelError("", "Não foi possível realizar essa operação");
                }
            }
            return View(pfToUpdate);
        }

        //GET: Clientes/DeletePj/5
        public async Task<IActionResult> DeletePj(int? id, bool? saveChangesError = false)
        {
            if(id == null)
            {
                return NotFound();
            }

            var pjToDelete = await _context.ClientePessoaJuridica
                           .Include(e => e.Enderecos)
                           .Include(c => c.Contatos)
                           .AsNoTracking()
                           .FirstOrDefaultAsync(pj => pj.ID == id);
            if(pjToDelete == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Exclusão falhou.";
            }
            return View(pjToDelete);
        }

        //POST: Clientes/DeletePj/5
        [HttpPost, ActionName("DeletePj")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedPj(int id)
        {
            var pj = await _context.ClientePessoaJuridica
                .Include(c => c.Contatos)
                .Include(e => e.Enderecos)
                .FirstOrDefaultAsync();
            if(pj == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.ClientePessoaJuridica.Remove(pj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction(nameof(DeletePj), new { id = id, saveChangesError = true });
            }
        }

        //GET: Clientes/DeletePf/5
        public async Task<IActionResult> DeletePf(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfToDelete = await _context.ClientePessoaFisica
                           .Include(e => e.Enderecos)
                           .Include(c => c.Contatos)
                           .AsNoTracking()
                           .FirstOrDefaultAsync(pf => pf.ID == id);
            if (pfToDelete == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Exclusão falhou.";
            }
            return View(pfToDelete);
        }

        //POST: Clientes/DeletePf/5
        [HttpPost, ActionName("DeletePf")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedPf(int id)
        {
            var pf = await _context.ClientePessoaFisica
                .Include(c => c.Contatos)
                .Include(e => e.Enderecos)
                .FirstOrDefaultAsync();

            if (pf == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.ClientePessoaFisica.Remove(pf);     
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction(nameof(DeletePf), new { id = id, saveChangesError = true });
            }
        }
    }
}
