import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import './pricedisplay.css';

export class PriceDisplay extends React.Component<any, any> {
    private formatPrice(value: number): string {
        if (value) {
            return 'R ' + value.toFixed(2);
        }

        return '';
    }

    public render() {
        if (this.props.pricing && this.props.pricing.totalPrice) {
            return <div className="price">
                Price: {this.formatPrice(this.props.pricing.totalPrice)} <small className="note"><i>*Note: VAT has increased by 1%</i></small>
            </div>;
        }

        return null;
    }
}