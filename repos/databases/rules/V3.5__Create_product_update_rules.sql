CREATE OR REPLACE RULE redirect_update_with_id_change AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 <> OLD.id % 10
        DO INSTEAD
        (
            INSERT INTO bench.products (id, name)
                VALUES (NEW.id, NEW.name
);
DELETE FROM bench.products
WHERE id = OLD.id;

);
CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id = NULL
        DO INSTEAD
        (
            UPDATE bench.products_0
            SET name = NEW.name;

UPDATE
    bench.products_1
SET
    name = NEW.name;

UPDATE
    bench.products_2
SET
    name = NEW.name;

UPDATE
    bench.products_3
SET
    name = NEW.name;

UPDATE
    bench.products_4
SET
    name = NEW.name;

UPDATE
    bench.products_5
SET
    name = NEW.name;

UPDATE
    bench.products_6
SET
    name = NEW.name;

UPDATE
    bench.products_7
SET
    name = NEW.name;

UPDATE
    bench.products_8
SET
    name = NEW.name;

UPDATE
    bench.products_9
SET
    name = NEW.name;

);
CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 0
        DO INSTEAD
        UPDATE bench.products_0
        SET name = NEW.name
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 1
        DO INSTEAD
        UPDATE bench.products_1
        SET name = NEW.name
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 2
        DO INSTEAD
        UPDATE bench.products_2
        SET name = NEW.name
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 3
        DO INSTEAD
        UPDATE bench.products_3
        SET name = NEW.name
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 4
        DO INSTEAD
        UPDATE bench.products_4
        SET name = NEW.name
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 5
        DO INSTEAD
        UPDATE bench.products_5
        SET name = NEW.name
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 6
        DO INSTEAD
        UPDATE bench.products_6
        SET name = NEW.name
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 7
        DO INSTEAD
        UPDATE bench.products_7
        SET name = NEW.name
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 8
        DO INSTEAD
        UPDATE bench.products_8
        SET name = NEW.name
    WHERE
        id = OLD.id;

CREATE OR REPLACE RULE redirect_update_to_produts_0 AS ON UPDATE TO bench.products
WHERE
    NEW.id % 10 = OLD.id % 10
    AND OLD.id % 10 = 9
        DO INSTEAD
        UPDATE bench.products_9
        SET name = NEW.name
    WHERE
        id = OLD.id;

