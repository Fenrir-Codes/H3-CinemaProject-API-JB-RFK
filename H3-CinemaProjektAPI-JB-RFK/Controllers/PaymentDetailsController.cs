using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using H3_CinemaProjektAPI_JB_RFK.DataBase;
using H3_CinemaProjektAPI_JB_RFK.Model;
using H3_CinemaProjektAPI_JB_RFK.Interfaces;

namespace H3_CinemaProjektAPI_JB_RFK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly IPaymentDetailsService _context;

        public PaymentDetailsController(IPaymentDetailsService context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult> GetPayment(int Id)
        {
            return Ok(await _context.GetPayment(Id));
        }

        [HttpGet("AllPayment")]
        public async Task<ActionResult> GetAllPayment()
        {
            try
            {
                List<PaymentDetails> paymentList = await _context.GetAllPaymentDetails();
                if (paymentList == null)
                {
                    return Problem("Nothing was returned");
                }
                if (paymentList.Count == 0)
                {
                    return NoContent(); // 204
                }
                return Ok(paymentList);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        //    // GET: api/PaymentDetails/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<PaymentDetails>> GetPaymentDetails(int id)
        //    {
        //        var paymentDetails = await _context.PaymentDetails.FindAsync(id);

        //        if (paymentDetails == null)
        //        {
        //            return NotFound();
        //        }

        //        return paymentDetails;
        //    }

        //    // PUT: api/PaymentDetails/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutPaymentDetails(int id, PaymentDetails paymentDetails)
        //    {
        //        if (id != paymentDetails.PaymentDetailsId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(paymentDetails).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PaymentDetailsExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/PaymentDetails
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<PaymentDetails>> PostPaymentDetails(PaymentDetails paymentDetails)
        //    {
        //        _context.PaymentDetails.Add(paymentDetails);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetPaymentDetails", new { id = paymentDetails.PaymentDetailsId }, paymentDetails);
        //    }

        //    // DELETE: api/PaymentDetails/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeletePaymentDetails(int id)
        //    {
        //        var paymentDetails = await _context.PaymentDetails.FindAsync(id);
        //        if (paymentDetails == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.PaymentDetails.Remove(paymentDetails);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool PaymentDetailsExists(int id)
        //    {
        //        return _context.PaymentDetails.Any(e => e.PaymentDetailsId == id);
        //    }
        }
    }
