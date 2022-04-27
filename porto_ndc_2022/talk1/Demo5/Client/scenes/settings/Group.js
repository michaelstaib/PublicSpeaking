import {Accordion, AccordionSummary, Stack, Typography} from '@mui/material';

import {ExpandLockedIcon, ExpandMoreIcon} from '@/icons';

export const Group = ({
  id,
  icon: Icon,
  title,
  active,
  disabled,
  children,
  onChange,
}) => (
  <Accordion
    expanded={id === active}
    disabled={disabled}
    onChange={(event, expanded) => {
      onChange(expanded ? id : false);
    }}
  >
    <AccordionSummary
      id={`panel-${id}-header`}
      expandIcon={disabled ? <ExpandLockedIcon /> : <ExpandMoreIcon />}
      aria-controls={`panel-${id}-content`}
    >
      <Stack direction="row" alignItems="center" gap={2}>
        <Icon color="action" />
        <Typography id={id} variant="h3">
          {title}
        </Typography>
      </Stack>
    </AccordionSummary>
    {children}
  </Accordion>
);
