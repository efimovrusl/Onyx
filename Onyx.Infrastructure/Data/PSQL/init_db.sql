DROP SCHEMA public CASCADE;
CREATE SCHEMA public;

CREATE TABLE IF NOT EXISTS addresses (
    id              UUID PRIMARY KEY,
    address_line1   VARCHAR(64) NOT NULL,
    address_line2   VARCHAR(64),
    address_line3   VARCHAR(64),
    postcode        VARCHAR(16),
    creation_date   DATE
);

CREATE TABLE IF NOT EXISTS users (
    id              UUID PRIMARY KEY,
    username        VARCHAR(32),
    first_name      VARCHAR(32),
    last_name       VARCHAR(32),
    address_id      UUID REFERENCES addresses(id),
    creation_date   TIMESTAMP DEFAULT NOW(),
    is_deleted      BOOLEAN DEFAULT false
);

CREATE TABLE IF NOT EXISTS login_secrets (
    user_id         UUID PRIMARY KEY REFERENCES users(id),
    hashed_password VARCHAR(32)
);

CREATE TABLE IF NOT EXISTS groups (
    id              UUID PRIMARY KEY,
    group_name      VARCHAR(32)
);

CREATE TABLE IF NOT EXISTS groups_users (
    user_id         UUID REFERENCES users(id),
    group_id        UUID REFERENCES groups(id),
    UNIQUE (user_id, group_id)
);

CREATE TYPE currency_type AS ENUM ('GBP', 'EUR', 'USD', 'CAD', 'PLN', 'UAH');

CREATE TABLE IF NOT EXISTS wallets (
    id              UUID PRIMARY KEY,
    user_id         UUID REFERENCES users(id),
    currency        currency_type,
    balance         DECIMAL,
    UNIQUE (user_id, currency)
);

CREATE TABLE IF NOT EXISTS orders (
    id              UUID PRIMARY KEY,
    currency        currency_type,
    total           DECIMAL,
    payer_id        UUID REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS orders_debtors (
    order_id        UUID REFERENCES orders(id),
    debtor_id       UUID REFERENCES users(id),
    debt_share      DOUBLE PRECISION
);
