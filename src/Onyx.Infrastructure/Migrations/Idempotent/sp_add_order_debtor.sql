CREATE OR REPLACE PROCEDURE sp_add_order_debtor(
    IN _order_id UUID,
    IN _debtor_id UUID,
    IN _debt_fraction DOUBLE PRECISION
)
    LANGUAGE plpgsql
AS
$$
BEGIN
    INSERT INTO orders_debtors (order_id, debtor_id, debt_fraction)
    VALUES (_order_id, _debtor_id, _debt_fraction);
END;
$$;