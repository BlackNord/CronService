create sequence test_id_seq;

create table test (
	id integer PRIMARY KEY DEFAULT nextval('test_id_seq'),
	created_at timestamp 
	);

create or replace function test_procedure()
	returns void
	as $$
	begin
		INSERT INTO public.test(created_at)
		VALUES (CURRENT_TIMESTAMP);
	end;$$
	language plpgsql
