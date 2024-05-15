CREATE OR REPLACE PROCEDURE sp_create_wallet(
    IN _user_id UUID,
    IN _currency currency_type
)
    LANGUAGE plpgsql
AS
$$
BEGIN
    INSERT INTO wallets
        (id, user_id, currency, balance)
    VALUES (gen_random_uuid(), _user_id, _currency, 0);
END;
$$;
