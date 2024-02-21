DROP SCHEMA public CASCADE;
CREATE SCHEMA public;

CALL sp_create_user(gen_random_uuid(), 'Pennyw1se', 'Ruslan', 'Yefimov', 'hashedPaSsWoRd');

DELETE FROM users
    WHERE true;





DO $$
    DECLARE found_user_id UUID;
    BEGIN
        SELECT id INTO found_user_id FROM users WHERE username = 'Pennyw1se';
        CALL sp_create_wallet(found_user_id,'GBP');
    END;
$$;

WITH _user_uuid AS (
    SELECT id FROM users WHERE username = 'Pennyw1se'
)
INSERT INTO wallets
        (id, user_id, currency, balance)
    VALUES
        (gen_random_uuid(), (SELECT id FROM _user_uuid), 'GBP', 5000.00)
