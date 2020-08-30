-- PROCEDURE: public.save_log(integer, text, text, text, text, text, text, text, date)

-- DROP PROCEDURE public.save_log(integer, text, text, text, text, text, text, text, date);

CREATE OR REPLACE PROCEDURE public.save_log(
	email text,
	messageexception text,
	innerexception text,
	stacktrace text,
	helplink text,
	hresult text,
	sourceexception text,
	targetsite text,
	createdate date)
LANGUAGE 'plpgsql'
AS $BODY$
      BEGIN
        INSERT INTO "Log"("Email",
        "MessageException",
        "InnerException",
        "StackTrace",
        "HelpLink",
        "HResult",
        "SourceException",
        "TargetSite",
        "CreateDate")
        VALUES(save_log.email, 
	       save_log.messageexception, 
	       save_log.innerexception, 
	       save_log.stacktrace, 
	       save_log.helplink, 
	       save_log.hresult,
	       save_log.sourceexception,
	       save_log.targetsite,
	       save_log.createdate);
      END;
  $BODY$;
