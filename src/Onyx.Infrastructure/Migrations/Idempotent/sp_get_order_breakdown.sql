CREATE OR REPLACE PROCEDURE sp_get_order_breakdown(
    IN _order_id UUID
)
    LANGUAGE plpgsql
AS
$$
BEGIN
    SELECT od.debtor_id               AS debtor_id,
           od.debt_fraction           AS debt_fraction,
           o.total * od.debt_fraction AS debt_calculated,
           o.currency                 AS currency
    FROM orders o
    JOIN orders_debtors od
         ON o.id = od.order_id;
END;
$$;
