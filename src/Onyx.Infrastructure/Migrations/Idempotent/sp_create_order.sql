CREATE OR REPLACE PROCEDURE sp_create_order(
    IN _payer_id UUID,
    IN _currency currency_type,
    IN _total DECIMAL
)
    LANGUAGE plpgsql
AS
$$
DECLARE
    new_uuid UUID := gen_random_uuid();
BEGIN
    INSERT INTO orders (id, currency, total, payer_id)
    VALUES (new_uuid, _currency, _total, _payer_id);
END;
$$;
