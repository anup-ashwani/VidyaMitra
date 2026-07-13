--
-- PostgreSQL database dump
--

\restrict YKIdlSxT7QTuEUO8a7OcK2bAhTEQWwVkfAvWkSjqv7RKPIxddzcqUjsV4rrVKHs

-- Dumped from database version 16.14 (Homebrew)
-- Dumped by pg_dump version 16.14 (Homebrew)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: StudentContactDetail; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."StudentContactDetail" (
    "ContactId" integer NOT NULL,
    "ProfileId" integer,
    "CountryCode" character(3),
    "PhoneNumber" character varying(10),
    "AlternatePhoneNumber" character varying(10),
    "PrimaryEmailId" character varying(50),
    "SecondaryEmailId" character varying(50),
    "C_AddressLine" character varying(500),
    "C_Country" character varying(25),
    "C_State" character varying(25),
    "C_City" character varying(25),
    "C_PinCode" character varying(5),
    "P_AddressLine1" character varying(200),
    "P_AddressLine2" character varying(200),
    "P_AddressLine3" character varying(200),
    "P_Country" character varying(25),
    "P_State" character varying(25),
    "P_City" character varying(25),
    "P_PinCode" character varying(5)
);


ALTER TABLE public."StudentContactDetail" OWNER TO postgres;

--
-- Name: StudentEmeregencyContact; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."StudentEmeregencyContact" (
    "EmeregencyContactId" integer NOT NULL,
    "ProfileId" integer,
    "PhoneNumber" character varying(10),
    "EmailId" character varying(50),
    "RelationShip" character varying(15),
    "AddressLine" character varying(200),
    "Country" character varying(25),
    "State" character varying(25),
    "City" character varying(25),
    "PinCode" character varying(5)
);


ALTER TABLE public."StudentEmeregencyContact" OWNER TO postgres;

--
-- Name: StudentNotification; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."StudentNotification" (
    "Id" integer NOT NULL,
    "ProfileId" integer,
    "EmailAlert" boolean,
    "SMSAlert" boolean,
    "AssignmentsReminder" boolean,
    "DuesReminder" boolean,
    "PushNotification" boolean,
    "WhatsAppAlert" boolean
);


ALTER TABLE public."StudentNotification" OWNER TO postgres;

--
-- Name: StudentParentDetail; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."StudentParentDetail" (
    "ParentID" integer NOT NULL,
    "ProfileId" integer,
    "FatherName" character varying(50) NOT NULL,
    "MotherName" character varying(50) NOT NULL,
    "GuardianName" character varying(50),
    "PhoneNumber" character varying(10),
    "Email" character varying(25),
    "AddressLine" character varying(200) NOT NULL,
    "Country" character varying(25) NOT NULL,
    "City" character varying(25),
    "State" character varying(25),
    "PinCode" character varying(5)
);


ALTER TABLE public."StudentParentDetail" OWNER TO postgres;

--
-- Name: StudentProfile; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."StudentProfile" (
    "Id" integer NOT NULL,
    "EnrollmentNumber" character varying(15),
    "Title" character varying(15) NOT NULL,
    "FirstName" character varying(50) NOT NULL,
    "MiddleName" character varying(50),
    "LastName" character varying(50) NOT NULL,
    "DateOfBirth" date NOT NULL,
    "Nationality" character varying(15) NOT NULL,
    "Religion" character varying(15),
    "AadharNumber" character varying(16),
    "BloodGroup" character varying(10),
    "ProfilePicture" bytea,
    "DigitalSignature" bytea,
    "LinkedInId" character varying(25),
    "GitHubId" character varying(25)
);


ALTER TABLE public."StudentProfile" OWNER TO postgres;

--
-- Data for Name: StudentContactDetail; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."StudentContactDetail" ("ContactId", "ProfileId", "CountryCode", "PhoneNumber", "AlternatePhoneNumber", "PrimaryEmailId", "SecondaryEmailId", "C_AddressLine", "C_Country", "C_State", "C_City", "C_PinCode", "P_AddressLine1", "P_AddressLine2", "P_AddressLine3", "P_Country", "P_State", "P_City", "P_PinCode") FROM stdin;
\.


--
-- Data for Name: StudentEmeregencyContact; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."StudentEmeregencyContact" ("EmeregencyContactId", "ProfileId", "PhoneNumber", "EmailId", "RelationShip", "AddressLine", "Country", "State", "City", "PinCode") FROM stdin;
\.


--
-- Data for Name: StudentNotification; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."StudentNotification" ("Id", "ProfileId", "EmailAlert", "SMSAlert", "AssignmentsReminder", "DuesReminder", "PushNotification", "WhatsAppAlert") FROM stdin;
\.


--
-- Data for Name: StudentParentDetail; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."StudentParentDetail" ("ParentID", "ProfileId", "FatherName", "MotherName", "GuardianName", "PhoneNumber", "Email", "AddressLine", "Country", "City", "State", "PinCode") FROM stdin;
\.


--
-- Data for Name: StudentProfile; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."StudentProfile" ("Id", "EnrollmentNumber", "Title", "FirstName", "MiddleName", "LastName", "DateOfBirth", "Nationality", "Religion", "AadharNumber", "BloodGroup", "ProfilePicture", "DigitalSignature", "LinkedInId", "GitHubId") FROM stdin;
\.


--
-- PostgreSQL database dump complete
--

\unrestrict YKIdlSxT7QTuEUO8a7OcK2bAhTEQWwVkfAvWkSjqv7RKPIxddzcqUjsV4rrVKHs

