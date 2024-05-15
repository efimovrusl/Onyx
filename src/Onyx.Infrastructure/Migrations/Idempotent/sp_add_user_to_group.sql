CREATE OR REPLACE PROCEDURE sp_add_user_to_group(
    IN _group_id UUID,
    IN _user_id  UUID,
    IN _is_admin BOOL DEFAULT FALSE
)
    LANGUAGE plpgsql
AS
$$
BEGIN
    INSERT INTO groups_users
        (group_id, user_id, is_admin)
    VALUES (_group_id, _user_id, _is_admin);
END;
$$;