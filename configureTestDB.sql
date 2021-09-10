create sequence test_id_seq;

create table test (
	id integer PRIMARY KEY DEFAULT nextval('test_id_seq'),
	created_at timestamp 
	);

create or replace procedure test_procedure()
	language plpgsql
	as $$
	begin
		INSERT INTO public.test(created_at)
		VALUES (CURRENT_TIMESTAMP);
		commit;
	end;$$