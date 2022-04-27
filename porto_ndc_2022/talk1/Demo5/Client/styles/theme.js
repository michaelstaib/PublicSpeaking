import {alpha, createTheme as ct, darken, lighten} from '@mui/material';

export const createTheme = (mode) => {
  const base = ct({
    palette: {
      mode,
      primary: {
        main: '#ff8c00',
      },
      secondary: {
        main: '#757972',
      },
      float: {
        main: '#15232c',
        contrastText: '#fff',
      },
      trend: {
        positive: '#098551',
        negative: '#cf202f',
        neutral: '#424242',
      },
    },
    spacing: 4,
    typography: {
      fontFamily:
        '-apple-system, BlinkMacSystemFont, Roboto, "Segoe UI", "Fira Sans", Avenir, "Helvetica Neue", "Lucida Grande", sans-serif',
      fontSizeTiny: '0.75rem',
      fontSizeSmall: '0.875rem',
      fontSizeMedium: '1rem',
      fontSizeLarge: '1.125rem',
      fontSizeHuge: '1.5rem',
      fontSizeMega: '3rem',
      h1: {
        fontSize: '2.25rem',
      },
      h2: {
        fontSize: '1.25rem',
      },
      h3: {
        fontSize: '1rem',
      },
      h4: {
        fontSize: '1rem',
      },
      h5: {
        fontSize: '1rem',
      },
      h6: {
        fontSize: '1rem',
      },
    },
    transitions: {
      easing: {
        ease: 'cubic-bezier(0.25, 0.1, 0.25, 1.0)',
      },
    },
    zIndex: {
      menu: 2000,
    },
    components: {
      MuiCssBaseline: {
        styleOverrides: {
          body: {
            overflow: 'hidden',
          },
        },
      },
      MuiAccordion: {
        defaultProps: {
          variant: 'outlined',
          square: true,
        },
        styleOverrides: {
          root: {
            borderRight: 0,
            borderLeft: 0,
            '&:before': {
              opacity: 0,
            },
            '&.Mui-disabled': {
              backgroundColor: 'unset',
            },
          },
        },
      },
      MuiButton: {
        styleOverrides: {
          root: {
            textTransform: 'capitalize',
          },
        },
      },
      MuiToggleButton: {
        styleOverrides: {
          root: {
            textTransform: 'capitalize',
          },
        },
      },
      MuiListItem: {
        styleOverrides: {
          root: {
            paddingTop: 0,
            paddingBottom: 0,
          },
        },
      },
      MuiListItemButton: {
        styleOverrides: {
          root: {
            paddingTop: 4,
            paddingBottom: 4,
          },
        },
      },
      MuiTab: {
        styleOverrides: {
          root: {
            textTransform: 'capitalize',
          },
        },
      },
      MuiTableCell: {
        styleOverrides: {
          root: {
            padding: 8,
          },
        },
      },
      MuiTableRow: {
        styleOverrides: {
          root: {
            '&:last-child th': {
              borderBottom: 0,
            },
            '&:last-child td': {
              borderBottom: 0,
            },
          },
        },
      },
      MuiTextField: {
        defaultProps: {
          variant: 'outlined',
          size: 'small',
        },
      },
    },
  });

  return ct(
    base,
    mode === 'light'
      ? {
          palette: {
            line: lighten(alpha(base.palette.divider, 1), 0.88),
            background: {
              neutral: '#cdcdcd',
            },
          },
        }
      : {
          palette: {
            line: darken(alpha(base.palette.divider, 1), 0.68),
            background: {
              neutral: '#4c4c4c',
            },
          },
        },
  );
};
