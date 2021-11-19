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

<<<<<<< Updated upstream
        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult> GetPayment(int Id)
        {
            return Ok(await _context.GetPayment(Id));
        }

=======
        #region get all payment details
>>>>>>> Stashed changes
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
        #endregion

        #region get payment detail (id)
        // GET: api/PaymentDetails
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPayment(int Id)
        {
            return Ok(await _context.GetPayment(Id));
        }
        #endregion

        #region create details
        // POST: api/PaymentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetails>> PostPaymentDetails(PaymentDetails paymentDetails)
        {
            return await _context.CreatePayment(paymentDetails);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPaymentDetails", new { id = paymentDetails.PaymentDetailsId }, paymentDetails);
        }
        #endregion

        #region update payment details
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePaymentDetails(int id, PaymentDetails data)
        {
            if (id != data.PaymentDetailsId)
            {
                return BadRequest("ID mismatch!");
            }

            try
            {
                await _context.UpdatePaymentDetails(id, data);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }
        #endregion

        #region delete payment detail (id)
        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetails(int id)
        {
            try
            {
                bool result = await _context.DeletePayment(id);
                if (!result)
                {
                    return Problem("Payment was not deleted, something went wrong");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        #endregion


        #region commented out code
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


        //    private bool PaymentDetailsExists(int id)
        //    {
        //        return _context.PaymentDetails.Any(e => e.PaymentDetailsId == id);
        //    }
        #endregion
    }
}
