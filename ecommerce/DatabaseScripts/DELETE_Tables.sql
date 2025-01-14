﻿DELETE FROM public."Address";
DELETE FROM public."Card";
DELETE FROM public."Comment";
DELETE FROM public."Log";
DELETE FROM public."CartDetailProductAuxiliaryNn";
DELETE FROM public."Product";
DELETE FROM public."CartDetail";
DELETE FROM public."Category";
DELETE FROM public."Purchase";
DELETE FROM public."Cart";
DELETE FROM public."User";

TRUNCATE public."User" RESTART IDENTITY CASCADE;
TRUNCATE public."Address" RESTART IDENTITY;
TRUNCATE public."Card" RESTART IDENTITY;
TRUNCATE public."Cart" RESTART IDENTITY CASCADE;
TRUNCATE public."Purchase" RESTART IDENTITY;
TRUNCATE public."CartDetail" RESTART IDENTITY CASCADE;
TRUNCATE public."Category" RESTART IDENTITY CASCADE;
TRUNCATE public."Product" RESTART IDENTITY CASCADE;
TRUNCATE public."Comment"  RESTART IDENTITY CASCADE;
TRUNCATE public."CartDetailProductAuxiliaryNn" RESTART IDENTITY;