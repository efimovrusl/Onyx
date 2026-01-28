CREATE OR REPLACE PROCEDURE sp_create_user(
    IN _new_uuid UUID,
    IN _email VARCHAR(64),
    IN _username VARCHAR(32),
    IN _first_name VARCHAR(32),
    IN _last_name VARCHAR(32),
    IN _hashed_password VARCHAR(128)
)
    LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO users
    (id, email, username, first_name, last_name)
    VALUES
        (_new_uuid, _email, _username, _first_name, _last_name);

    INSERT INTO login_secrets
    (user_id, hashed_password)
    VALUES
        (_new_uuid, _hashed_password);
END;
$$; 