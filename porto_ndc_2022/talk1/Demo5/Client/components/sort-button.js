import {IconButton, Menu, MenuItem} from '@mui/material';
import {useRef} from 'react';

import {useToggle} from '@/hooks';
import {SortIcon} from '@/icons';

export const SortButton = ({options, disabled, active, onChange}) => {
  const [open, toggle, setOpen] = useToggle(false);
  const anchorRef = useRef(null);

  return (
    <>
      <IconButton
        ref={anchorRef}
        id="sort-button"
        size="medium"
        disabled={disabled}
        aria-controls={open ? 'sort-menu' : undefined}
        aria-haspopup="true"
        aria-expanded={open ? 'true' : undefined}
        onClick={toggle}
      >
        <SortIcon />
      </IconButton>
      <Menu
        id="sort-menu"
        anchorEl={anchorRef.current}
        open={open}
        MenuListProps={{'aria-labelledby': 'sort-button'}}
        onClose={toggle}
      >
        {options.map(({title}, index) => (
          <MenuItem
            key={title}
            selected={index === active}
            onClick={() => {
              setOpen(false);

              if (index !== active) {
                onChange?.(index);
              }
            }}
          >
            {title}
          </MenuItem>
        ))}
      </Menu>
    </>
  );
};
