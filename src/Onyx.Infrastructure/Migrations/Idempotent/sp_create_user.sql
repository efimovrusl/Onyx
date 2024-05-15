CREATE OR REPLACE PROCEDURE sp_create_user(
    IN _username VARCHAR(32),
    IN _first_name VARCHAR(32),
    IN _last_name VARCHAR(32),
    IN _hashed_password VARCHAR(128)
)
    LANGUAGE plpgsql
AS
$$
DECLARE
    new_uuid UUID := gen_random_uuid();
BEGIN
    INSERT INTO users
        (id, username, first_name, last_name)
    VALUES (new_uuid, _username, _first_name, _last_name);

    INSERT INTO login_secrets
        (user_id, hashed_password)
    VALUES (new_uuid, _hashed_password);
END;
$$;
