import React from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import CancelIcon from '@material-ui/icons/Cancel';
import Tooltip from '@material-ui/core/Tooltip';
import IconButton from '@material-ui/core/IconButton';

export default function ConfirmCancel(props) {
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
       <Tooltip title="Cancelar">
        <IconButton aria-label="cancelar" size='small'>
          <CancelIcon onClick={handleClickOpen} />
        </IconButton>
       </Tooltip>
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">{props.title}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            {props.text}
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button
            onClick={handleClose}
            size="small"
            color="default"
          >
            {props.labelCancel}
          </Button>
          <Button
            onClick={() => {
              setOpen(false);
              props.callBack(setOpen);
            }}
            size="small"
            color="primary"
            autoFocus
          >
            {props.labelAccept}
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}
