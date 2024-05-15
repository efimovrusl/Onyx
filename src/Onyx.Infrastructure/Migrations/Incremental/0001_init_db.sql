DROP SCHEMA public CASCADE;
CREATE SCHEMA public;

CREATE TABLE addresses
(
    id            UUID PRIMARY KEY,
    address_line1 VARCHAR(64) NOT NULL,
    address_line2 VARCHAR(64),
    address_line3 VARCHAR(64),
    postcode      VARCHAR(16),
    creation_date DATE        NOT NULL
);

CREATE TABLE users
(
    id            UUID PRIMARY KEY,
    username      VARCHAR(32)             NOT NULL,
    first_name    VARCHAR(32)             NOT NULL,
    last_name     VARCHAR(32)             NOT NULL,
    address_id    UUID REFERENCES addresses (id),
    creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
    is_deleted    BOOLEAN   DEFAULT FALSE NOT NULL
);

CREATE TABLE login_secrets
(
    user_id         UUID PRIMARY KEY REFERENCES users (id),
    hashed_password VARCHAR(32) NOT NULL
);

CREATE TABLE groups
(
    id         UUID PRIMARY KEY,
    group_name VARCHAR(32) NOT NULL
);

CREATE TABLE groups_users
(
    group_id UUID REFERENCES groups (id) NOT NULL,
    user_id  UUID REFERENCES users (id)  NOT NULL,
    is_admin BOOL DEFAULT FALSE          NOT NULL,
    PRIMARY KEY (group_id, user_id)
);

CREATE TABLE friends --should be recorded two-way
(
    user_id1 UUID REFERENCES users (id) NOT NULL,
    user_id2 UUID REFERENCES users (id) NOT NULL,
    PRIMARY KEY (user_id1, user_id2)
);

CREATE TYPE currency_type AS ENUM ('GBP', 'EUR', 'USD', 'CAD', 'PLN', 'UAH');

CREATE TABLE wallets
(
    id       UUID PRIMARY KEY,
    user_id  UUID REFERENCES users (id) NOT NULL,
    currency currency_type              NOT NULL,
    balance  DECIMAL                    NOT NULL,
    UNIQUE (user_id, currency)
);

CREATE TABLE orders
(
    id       UUID PRIMARY KEY,
    currency currency_type              NOT NULL,
    total    DECIMAL                    NOT NULL,
    payer_id UUID REFERENCES users (id) NOT NULL
);

CREATE TABLE orders_debtors
(
    order_id      UUID REFERENCES orders (id) NOT NULL,
    debtor_id     UUID REFERENCES users (id)  NOT NULL,
    debt_fraction DOUBLE PRECISION            NOT NULL,
    PRIMARY KEY (order_id, debtor_id)
);
