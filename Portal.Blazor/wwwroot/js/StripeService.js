let stripe;
let elements;
const style = { 
    base: {
        fontSize: '3.333vw',
        fontWeight: '600',
        color: 'gray'
    }
};
let card;
let dotnet;

export function UpdateBreakpoint(breakpoint) {
    if (!card) return;
    console.log(breakpoint);
    if (breakpoint >= 3)
        style.base.fontSize = '16px';
    else if (breakpoint === 2)
        style.base.fontSize = '12px';
    else
        style.base.fontSize = '3.333vw';
    card.update({ style });
}

export function Initialize(key, _dotnet) {
    if (stripe) return;
    stripe = Stripe(key);
    elements = stripe.elements();
    dotnet = _dotnet;
}

export function CreateInstance(elementId) {
    try {
        if (!card) {
            card = elements.create('card', { style });
            card.on('change', ({complete, empty, error}) => {
                let status = complete ? 1 : empty ? 0 : 2;
                if (error && typeof error !== "string")
                    error = JSON.stringify(error);
                dotnet.invokeMethodAsync('UpdateStripeStatus', status, error);
            });
        }
        card.mount(`#${elementId}`);
    }
    catch {}
}

export async function GetPaymentId(secret) {
    const result = await stripe.handleCardAction(secret)
    if (result.error) {
        if (typeof result.error !== "string")
            result.error = JSON.stringify(result.error)
        dotnet.invokeMethodAsync('UpdateStripeStatus', 2, result.error);
        return null;
    }
    return result.paymentIntent.id;
}

export function Detach() {
    if (!card) return;
    card.unmount();
}

export function Destroy() {
    if (!card) return;
    card.destroy();
    card = null;
}

export async function CreatePaymentMethod() {
    const result = await stripe.createPaymentMethod({
        type: 'card',
        card
    });
    if (result.error) {
        if (typeof result.error !== "string")
            result.error = JSON.stringify(result.error)
        dotnet.invokeMethodAsync('UpdateStripeStatus', 2, result.error);
        return null;
    }
    return {
      Brand: result.paymentMethod.card.brand,
      ExpirationMonth: result.paymentMethod.card.exp_month,
      ExpirationYear: result.paymentMethod.card.exp_year,
      Last4: result.paymentMethod.card.last4,
      Cardholder: result.paymentMethod.billing_details.name,
      Id: result.paymentMethod.id
    };
}