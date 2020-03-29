CREATE OR REPLACE RULE redirect_insert_to_produts_0 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 0
        DO INSTEAD
        INSERT INTO bench.products_0
            VALUES (
                NEW.id, NEW.name
);

CREATE OR REPLACE RULE redirect_insert_to_produts_1 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 1
        DO INSTEAD
        INSERT INTO bench.products_1
            VALUES (
                NEW.id, NEW.name
);

CREATE OR REPLACE RULE redirect_insert_to_produts_2 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 2
        DO INSTEAD
        INSERT INTO bench.products_2
            VALUES (
                NEW.id, NEW.name
);

CREATE OR REPLACE RULE redirect_insert_to_produts_3 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 3
        DO INSTEAD
        INSERT INTO bench.products_3
            VALUES (
                NEW.id, NEW.name
);

CREATE OR REPLACE RULE redirect_insert_to_produts_4 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 4
        DO INSTEAD
        INSERT INTO bench.products_4
            VALUES (
                NEW.id, NEW.name
);

CREATE OR REPLACE RULE redirect_insert_to_produts_5 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 5
        DO INSTEAD
        INSERT INTO bench.products_5
            VALUES (
                NEW.id, NEW.name
);

CREATE OR REPLACE RULE redirect_insert_to_produts_6 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 6
        DO INSTEAD
        INSERT INTO bench.products_6
            VALUES (
                NEW.id, NEW.name
);

CREATE OR REPLACE RULE redirect_insert_to_produts_7 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 7
        DO INSTEAD
        INSERT INTO bench.products_7
            VALUES (
                NEW.id, NEW.name
);

CREATE OR REPLACE RULE redirect_insert_to_produts_8 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 8
        DO INSTEAD
        INSERT INTO bench.products_8
            VALUES (
                NEW.id, NEW.name
);

CREATE OR REPLACE RULE redirect_insert_to_produts_9 AS ON INSERT TO bench.products
WHERE
    NEW.id % 10 = 9
        DO INSTEAD
        INSERT INTO bench.products_9
            VALUES (
                NEW.id, NEW.name
);

