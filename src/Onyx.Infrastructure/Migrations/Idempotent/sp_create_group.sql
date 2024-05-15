CREATE OR REPLACE PROCEDURE sp_create_group(
    IN _name VARCHAR(32),
    IN _admin_user_id UUID
)
    LANGUAGE plpgsql
AS
$$
DECLARE
    new_uuid UUID := gen_random_uuid();
BEGIN
    INSERT INTO groups
        (id, group_name)
    VALUES (new_uuid, _name);

    CALL sp_add_user_to_group(new_uuid, _admin_user_id, TRUE);
END;
$$;