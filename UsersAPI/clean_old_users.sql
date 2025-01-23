CREATE OR REPLACE FUNCTION CleanOldUsers(date_limit DATE) 
    RETURNS void AS $$
BEGIN
DELETE FROM users WHERE "createdAt" < date_limit;
END;
    $$ LANGUAGE plpgsql;