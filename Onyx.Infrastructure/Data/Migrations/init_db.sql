DROP SCHEMA public CASCADE;
CREATE SCHEMA IF NOT EXISTS public;

CREATE TABLE IF NOT EXISTS users (
    id              UUID PRIMARY KEY,
    email           VARCHAR(64) NOT NULL,
    username        VARCHAR(32) NOT NULL,
    first_name      VARCHAR(32) NOT NULL,
    last_name       VARCHAR(32) NOT NULL,
    created_at   TIMESTAMP DEFAULT NOW() NOT NULL,
    is_deleted      BOOLEAN DEFAULT false NOT NULL
);

CREATE TABLE IF NOT EXISTS login_secrets (
    user_id         UUID PRIMARY KEY REFERENCES users(id),
    hashed_password VARCHAR(32) NOT NULL
);

CREATE TABLE IF NOT EXISTS groups (
    id              UUID PRIMARY KEY,
    name      VARCHAR(32) NOT NULL
);

CREATE TABLE IF NOT EXISTS groups_users (
    user_id         UUID REFERENCES users(id),
    group_id        UUID REFERENCES groups(id),
    
    UNIQUE (user_id, group_id)
);

CREATE TYPE currency_type AS ENUM ('GBP', 'EUR', 'USD', 'CAD', 'PLN', 'UAH');

CREATE TABLE IF NOT EXISTS expenses (
    id              UUID PRIMARY KEY,
    group_id        UUID REFERENCES groups(id),
    description     VARCHAR(64) NOT NULL,
    amount          DECIMAL NOT NULL,
    currency        currency_type NOT NULL,
    created_at      TIMESTAMP DEFAULT NOW() NOT NULL
);

CREATE TABLE IF NOT EXISTS expenses_payers (
    expense_id      UUID REFERENCES expenses(id),
    payer_id        UUID REFERENCES users(id),
    amount          DECIMAL NOT NULL,
    currency        currency_type NOT NULL
);

CREATE TABLE IF NOT EXISTS expenses_consumers (
    expense_id      UUID REFERENCES expenses(id),
    consumer_id     UUID REFERENCES users(id),
    debt_share      DOUBLE PRECISION
);
