## Must use:

- MySQL database
- db_schema.sql for DB creation

## 1. Task

### Get numbers of bikes sold in Jan and Feb 2020 per each vehicle make.
- Display only those makes where total sales are more than 1000 units
- Display all makes (including those where sales are not made)

## 2. Task

### Get current weekly payment amount for each loan. 
- Table m_loan_repayment_schedule contains weekly payment records. 
- Weekly payment record should be selected for the first week where obligations are not met (value for field completed_derived=0)

## 3. Task

### Calculate current balance (scheduled amount - payed amount) for each loan. 
- Use tables m_loan_repayment_schedule for payment schedule data. 
- Total scheduled payment amount on current date must be calculated by sum of all amount field values. 
- Some values can be null. 
- Payment data are stored in table m_loan_transaction.
