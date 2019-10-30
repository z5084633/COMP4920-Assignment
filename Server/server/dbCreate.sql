CREATE TABLE public.accounts
(
account character varying(64) primary key, 
password character varying(32) NOT NULL, 
nickName character varying (32) NOT NULL
);
CREATE TABLE public.friends
(
account_from character varying(64), 
account_to character varying(64), 
PRIMARY KEY (account_from, account_to)
);