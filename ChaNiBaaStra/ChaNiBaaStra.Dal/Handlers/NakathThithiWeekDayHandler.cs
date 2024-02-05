using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nido.Common.BackEnd;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using EntityFramework.Extensions;
using ChaNiBaaStra.Dal.Models;
using ChaNiBaaStra.Dal.DB;

namespace ChaNiBaaStra.Dal.Handlers
{
    /// <summary>
    /// Handler method for NakathThithiWeekDay Table. You will have one handler for each table.
    /// </summary>
    /// <remarks>
    /// You may write any additional data handling operations
    /// related to NakathThithiWeekDay table in here.
    /// </remarks>
    public class NakathThithiWeekDayHandler : HandlerBase<NakathThithiWeekDay, AstroDatabaseDBContext>
    {
        protected override Type LogPrefix
        {
            get { return this.GetType(); }
        }

        /// <summary>
        /// Created by RocketFramework
        /// </summary>
        /// <remarks>
        /// This is a sample method. 
        /// You may modify this method as needed.
        /// 
        /// If you want to do complex data loading, you can write a 
        /// SP that accept multiple parameters and then call multiple tables, 
        /// views through it to select the particular record set you want.
        /// 
        /// Important: You have to create a 'Model' object to directly match the receiving object.
        /// 
        /// Then through a SP call you may load the records.
        /// </remarks>
        public GenericResponse<IEnumerable<NakathThithiWeekDay>> MyCustomMethod()
        {
            try
            {
                // Call the SP or any other custom SQL query with or wihout parameters
                // This is good if the provided methods are not sifficient to select the records
                //
                // The example below explain how to call a SP with or without parameters
                //
                // return db.ExecuteStoredProcedure<FinanceStatusView>("PRHeader_S_FinancePRStatus @BudgetStatusId,@PRStatusId",
                // new SqlParameter("@BudgetStatusId", 1), new SqlParameter("@PRStatusId", prStatusId));
                // 
                // return db.ExecuteStoredProcedure<FinanceStatusView>("PRHeader_S_FinancePRStatus");
                //
                IEnumerable<NakathThithiWeekDay> s = this._context.ExecuteStoredProcedure<NakathThithiWeekDay>("Select * from NakathThithiWeekDay", null);
                // return UpdateSuccessResponse(<Updated NakathThithiWeekDay>);
                // return DeleteSuccessResponse(<Deleted NakathThithiWeekDay>);
                return SelectSuccessResponse(s);
            }
            catch (Exception e)
            {
                return HandleException<IEnumerable<NakathThithiWeekDay>>(e);
            }
        }
	}
}
